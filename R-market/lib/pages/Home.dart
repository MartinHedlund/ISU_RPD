import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:r_market/models/basketproduct.dart';

import '../models/product.dart';
import '../shared/horizontalcard.dart';
import '../shared/productcard.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final Stream<QuerySnapshot> _usersStream =
      FirebaseFirestore.instance.collection('products').snapshots();

  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider(
      create: (_) => BasketProduct(),
      builder: (context, child) => Scaffold(
        body: StreamBuilder(
          stream: _usersStream,
          builder: (_, AsyncSnapshot<QuerySnapshot> snapshot) {
            if (snapshot.hasError) {
              return const Text('Something went wrong');
            }
            if (snapshot.connectionState == ConnectionState.waiting) {
              return const Text(
                "Loading",
                textAlign: TextAlign.center,
              );
            }
            var documents = snapshot.data?.docs ?? [];
            var products = documents
                .map((documents) => Product.fromFirestoreStream(documents))
                .toList();
            return NestedScrollView(
              floatHeaderSlivers: true,
              headerSliverBuilder: ((context, innerBoxIsScrolled) {
                return [
                  SliverList(
                    delegate: SliverChildListDelegate([
                      horizontalList(products),
                    ]),
                  )
                ];
              }),
              body: Column(
                children: [
                  verticalList(products),
                  Container(
                      alignment: Alignment.bottomRight,
                      color: Colors.transparent,
                      child: ElevatedButton(
                        onPressed: () {
                          var bask = context.read<BasketProduct>();
                          final snackBar = SnackBar(
                            backgroundColor: Colors.teal,
                            behavior: SnackBarBehavior.floating,
                            shape: const StadiumBorder(),
                            margin: EdgeInsets.only(
                              bottom: MediaQuery.of(context).size.height * 0.75,
                            ),
                            content: Text(
                              'Заказ оформлен на сумму ${bask.price}р',
                              style: const TextStyle(fontSize: 16),
                              textAlign: TextAlign.center,
                            ),
                          );
                          ScaffoldMessenger.of(context).showSnackBar(snackBar);
                          _addProduct(bask);
                        },
                        style: ButtonStyle(
                          shape: MaterialStateProperty.all<OutlinedBorder>(
                            StadiumBorder(),
                          ),
                          backgroundColor: MaterialStateProperty.all<Color>(
                              Color.fromARGB(255, 151, 171, 244)),
                          elevation: MaterialStateProperty.all<double>(4),
                          padding:
                              MaterialStateProperty.all<EdgeInsetsGeometry>(
                            EdgeInsets.symmetric(horizontal: 20, vertical: 10),
                          ),
                        ),
                        child: Text(
                          "Оформить заказ на сумму: ${context.watch<BasketProduct>().price}р",
                          style: TextStyle(fontSize: 14),
                        ),
                      ))
                ],
              ),
            );
          },
        ),
      ),
    );
  }
}

void _addProduct(BasketProduct obj) async {
  await FirebaseFirestore.instance
      .collection('basketproducts')
      .doc(FirebaseAuth.instance.currentUser!.uid)
      .collection("Orders")
      .doc()
      .set(obj.toFirestore());
}

Widget horizontalList(var products) {
  return SizedBox(
    height: 300,
    child: ListView.builder(
        scrollDirection: Axis.horizontal,
        itemCount: products.length,
        itemBuilder: (context, index) => HorizontalCardWidget(
              products: products[index],
            )),
  );
}

Widget verticalList(var products) {
  return Expanded(
    child: ListView.builder(
        scrollDirection: Axis.vertical,
        itemCount: products.length,
        itemBuilder: (context, index) => ProductCard(
              product: products[index],
            )),
  );
}

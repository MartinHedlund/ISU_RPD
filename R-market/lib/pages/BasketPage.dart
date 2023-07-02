import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';

import '../models/basketproduct.dart';
import '../shared/basketCard.dart';
import 'OrderPage.dart';

class BasketPage extends StatefulWidget {
  const BasketPage({super.key});

  @override
  State<BasketPage> createState() => _BasketPageState();
}

class _BasketPageState extends State<BasketPage> {
  final Stream<QuerySnapshot> _ordersStream = FirebaseFirestore.instance
      .collection('basketproducts')
      .doc(FirebaseAuth.instance.currentUser!.uid)
      .collection("Orders")
      .snapshots();

  @override
  Widget build(BuildContext context) {
    // BasketProduct basketProduct = new BasketProduct();
    // basketProduct.price = 10;
    // basketProduct.count = 5;
    // basketProduct.products = List<Product>.filled(
    //     5, Product(titul: "123123hui", price: 120, sub: "1231wfdvsfgdf;jwklf"));
    // final db = FirebaseFirestore.instance
    //     .collection("basketproducts")
    //     .doc(FirebaseAuth.instance.currentUser!.uid)
    //     .collection("Orders");
    // db
    //     .withConverter(
    //       fromFirestore: BasketProduct.fromFirestore,
    //       toFirestore: (BasketProduct bask, optios) => bask.toFirestore(),
    //     )
    //     .doc()
    //     .set(basketProduct);

    return StreamBuilder(
        stream: _ordersStream,
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
          var productlist = documents
              .map((documents) => BasketProduct.fromFirestoreStream(documents))
              .toList();
          return _vertical_list(productlist);
        });
  }
}

Widget _vertical_list(List<BasketProduct> products) {
  return ListView.builder(
      scrollDirection: Axis.vertical,
      itemCount: products.length,
      itemBuilder: (context, index) => InkWell(
          onTap: () {
            Navigator.push(
              context,
              MaterialPageRoute(
                  builder: (context) =>
                      OrderPage(basketProductList: products[index].products!)),
            );
          },
          child: BasketCard(basketProduct: products[index])));
}

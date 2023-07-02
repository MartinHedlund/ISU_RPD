// ignore_for_file: public_member_api_docs, sort_constructors_first, must_be_immutable
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/material.dart';

import 'package:r_market/models/basketproduct.dart';
import 'package:r_market/models/product.dart';

class BasketCard extends StatelessWidget {
  // /basketproducts/userUID/orderID/listorders
  BasketProduct basketProduct;
  BasketCard({
    Key? key,
    required this.basketProduct,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
        child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: ListTile(
              minLeadingWidth: 4,
              title: Text(
                "Заказ № ${basketProduct.id}",
                style: const TextStyle(fontSize: 12),
              ),
              subtitle: Text(
                  "Количетво товаров: ${basketProduct.count}\nСумма заказа: ${basketProduct.price}р   "),
            )));
  }
}

// // class _ProductCardState extends State<ProductCard> {
//   bool flag = true;
//   late String textbutton;
//   int cout = 0;

//   @override
//   Widget build(BuildContext context) {
//     return Card(
//       child: Padding(
//           padding: const EdgeInsets.all(8.0),
//           child: StreamBuilder(
//               stream: _cardStream,
//               builder: (_, AsyncSnapshot<QuerySnapshot> snapshot) {
//                 if (snapshot.hasError) {
//                   return const Text('Something went wrong');
//                 }

//                 if (snapshot.connectionState == ConnectionState.waiting) {
//                   return const Text(
//                     "Loading",
//                     textAlign: TextAlign.center,
//                   );
//                 }

//                 var documents = snapshot.data?.docs ?? [];
//                 var cardlist = documents
//                     .map((documents) =>
//                         BasketProduct.fromFirestoreStream(documents))
//                     .toList();
//                 return ListView.builder(
//                     itemCount: cardlist.length,
//                     itemBuilder: (context, index) => StockCard(
//                           card: cardlist[index],
//                         ));
//               })),
//     );
//   }
// }

Future<Product?> FindProdugt(String id) async {
  final db = FirebaseFirestore.instance;
  final ref = db.collection("products").doc(id).withConverter<Product>(
        fromFirestore: Product.fromFirestore,
        toFirestore: (Product prod, _) => prod.toFirestore(),
      );

  final docSnap = await ref.get();
  final prod = docSnap.data(); // Con
  return prod;
}


// void _addProduct(BasketProduct obj) async {
//   await FirebaseFirestore.instance
//       .collection('basketproducts')
//       .doc(FirebaseAuth.instance.currentUser!.uid)
//       .collection("Orders")
//       .doc()
//       .set(obj.toFirestore());
// }

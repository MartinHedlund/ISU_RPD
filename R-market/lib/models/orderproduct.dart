import 'package:cloud_firestore/cloud_firestore.dart';

import 'product.dart';

class OrderProduct extends Product {
  final int count_order_product;

  OrderProduct({
    required this.count_order_product,
    String? id,
    String? titul,
    String? sub,
    dynamic price,
    String? src,
  }) : super(id: id, titul: titul, sub: sub, price: price, src: src);

  factory OrderProduct.toMap(Map temp) {
    return OrderProduct(
      count_order_product: temp['count_order_product'],
      id: temp['id'],
      titul: temp['titul'],
      sub: temp['sub'],
      price: temp['price'],
      src: temp['src'],
    );
  }

  factory OrderProduct.fromFirestore(
    DocumentSnapshot<Map<String, dynamic>> snapshot,
    SnapshotOptions? options,
  ) {
    final data = snapshot.data();
    return OrderProduct(
      count_order_product: data?['count_order_product'],
      id: snapshot.id,
      titul: data?['titul'],
      sub: data?['sub'],
      price: data?['price'],
      src: data?['src'],
    );
  }

  factory OrderProduct.fromFirestoreStream(
    QueryDocumentSnapshot<Object?> document,
  ) {
    final data = document.data()! as Map<String, dynamic>;

    return OrderProduct(
      count_order_product: data['count_order_product'],
      id: document.id,
      titul: data['titul'],
      sub: data['sub'],
      price: data['price'],
      src: data['src'],
    );
  }

  Map<String, dynamic> toFirestore() {
    final Map<String, dynamic> data = super.toFirestore();
    data['count_order_product'] = count_order_product;
    return data;
  }
}

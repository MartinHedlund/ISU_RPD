import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/foundation.dart';
import 'package:r_market/models/orderproduct.dart';

import 'package:r_market/models/product.dart';

class BasketProduct with ChangeNotifier {
  String? id;
  int? count = 0;
  dynamic price = 0;
  List<OrderProduct>? products;

  BasketProduct({
    this.id,
    this.count = 0,
    this.price = 0,
    this.products,
  });

  void addProduct(int count, dynamic price, Product product, String id) {
    this.count != null ? this.count = this.count! + count : null;
    this.price != null ? this.price = this.price! + price : null;
    this.id ??= id;
    products ??= List.empty(growable: true);
    OrderProduct orderProduct = OrderProduct(
      id: product.id,
      titul: product.titul,
      price: product.price,
      sub: product.sub,
      src: product.src,
      count_order_product: count,
    );
    products!.add(orderProduct);
    notifyListeners();
  }

  factory BasketProduct.fromFirestore(
    DocumentSnapshot<Map<String, dynamic>> snapshot,
    SnapshotOptions? options,
  ) {
    final data = snapshot.data();
    final tempdata = data?['products']! as List<dynamic>;
    var products =
        tempdata.map<OrderProduct>((e) => OrderProduct.toMap(e)).toList();
    return BasketProduct(
      id: snapshot.id,
      price: data?['price'],
      count: data?['count'],
      products: products is Iterable ? List<OrderProduct>.from(products) : null,
    );
  }

  factory BasketProduct.fromFirestoreStream(
    QueryDocumentSnapshot<Object?> document,
  ) {
    final data = document.data()! as Map<String, dynamic>;
    final tempdata = data['products'];
    print(tempdata.toString());
    var products = tempdata != null
        ? tempdata.map<OrderProduct>((e) => OrderProduct.toMap(e)).toList()
        : null;
    return BasketProduct(
      id: document.id,
      price: data['price'],
      count: data['count'],
      products: products is List<OrderProduct> ? products : null,
    );
  }
  Map<String, dynamic> toFirestore() {
    return {
      if (id != null) "id": id,
      if (price != null) "price": price,
      if (count != null) "count": count,
      if (products != null) 'products': products!.map((e) => e.toFirestore())
    };
  }

  @override
  String toString() {
    return 'BasketProduct(id: $id, count: $count, price: $price, products: $products)';
  }

  @override
  bool operator ==(covariant BasketProduct other) {
    if (identical(this, other)) return true;

    return other.id == id &&
        other.count == count &&
        other.price == price &&
        listEquals(other.products, products);
  }

  @override
  int get hashCode {
    return id.hashCode ^ count.hashCode ^ price.hashCode ^ products.hashCode;
  }
}

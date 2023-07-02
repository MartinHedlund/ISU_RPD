import 'package:cloud_firestore/cloud_firestore.dart';

class Product {
  final String? id;
  final String? titul;
  final String? sub;
  final dynamic price;
  final String? src;

  Product({this.price, this.sub, this.titul, this.id, this.src});

  factory Product.toMap(Map temp) {
    return Product(
        id: temp['id'],
        titul: temp['titul'],
        sub: temp['sub'],
        price: temp['price'],
        src: temp["src"]);
  }

  factory Product.fromFirestore(
    DocumentSnapshot<Map<String, dynamic>> snapshot,
    SnapshotOptions? options,
  ) {
    final data = snapshot.data();
    return Product(
        id: snapshot.id,
        titul: data?['titul'],
        sub: data?['sub'],
        price: data?['price'],
        src: data?["src"]);
  }
  factory Product.fromFirestoreStream(
    QueryDocumentSnapshot<Object?> document,
  ) {
    final data = document.data()! as Map<String, dynamic>;

    return Product(
        id: document.id,
        titul: data['titul'],
        sub: data['sub'],
        price: data['price'],
        src: data["src"]);
  }
  Map<String, dynamic> toFirestore() {
    return {
      if (titul != null) "titul": titul,
      if (sub != null) "sub": sub,
      if (price != null) "price": price,
      if (src != null) "src": src
    };
  }
}

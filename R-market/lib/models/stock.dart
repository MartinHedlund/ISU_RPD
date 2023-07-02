import 'package:cloud_firestore/cloud_firestore.dart';

class Stock {
  final String? img;
  final String? titul;
  final String? desc;
  final FirebaseFirestore db = FirebaseFirestore.instance;

  Stock({this.desc, this.img, this.titul});

  factory Stock.fromFirestore(
    DocumentSnapshot<Map<String, dynamic>> snapshot,
    SnapshotOptions? options,
  ) {
    final data = snapshot.data()!;
    return Stock(
      titul: data['titul'],
      img: data['img'],
      desc: data['desc'],
    );
  }

  factory Stock.fromFirestoreStream(
    QueryDocumentSnapshot<Object?> document,
  ) {
    final data = document.data()! as Map<String, dynamic>;

    return Stock(
      titul: data['titul'],
      img: data['img'],
      desc: data['desc'],
    );
  }
  Map<String, dynamic> toFirestore() {
    return {
      if (titul != null) "titul": titul,
      if (img != null) "img": img,
      if (desc != null) "desc": desc,
    };
  }
}

Future<void> AddStockCard(Stock card) async {
  final docRef = FirebaseFirestore.instance
      .collection('card')
      .withConverter(
          fromFirestore: Stock.fromFirestore,
          toFirestore: (Stock stock, option) => stock.toFirestore())
      .doc();
  docRef.set(card);
}

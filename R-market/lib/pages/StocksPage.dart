import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:r_market/models/stock.dart';
import 'package:r_market/shared/stockcard.dart';

class StocksPage extends StatefulWidget {
  const StocksPage({super.key});

  @override
  State<StocksPage> createState() => _StocksPageState();
}

class _StocksPageState extends State<StocksPage> {
  final Stream<QuerySnapshot> _cardStream =
      FirebaseFirestore.instance.collection('card').snapshots();

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: StreamBuilder(
            stream: _cardStream,
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
              var cardlist = documents
                  .map((documents) => Stock.fromFirestoreStream(documents))
                  .toList();
              return ListView.builder(
                  itemCount: cardlist.length,
                  itemBuilder: (context, index) => StockCard(
                        card: cardlist[index],
                      ));
            }));
  }
}

import 'package:flutter/material.dart';
import 'package:r_market/shared/descripton_wiget.dart';

import '../models/stock.dart';

class StockCard extends StatefulWidget {
  const StockCard({super.key, required this.card});
  final Stock card;
  @override
  State<StockCard> createState() => _StockCardState();
}

class _StockCardState extends State<StockCard> {
  @override
  Widget build(BuildContext context) {
    return Card(
      margin: const EdgeInsets.symmetric(vertical: 10.5, horizontal: 7.5),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Center(
            child: SizedBox(
              width: MediaQuery.of(context).size.width,
              height: 250,
              child: Image(
                image: NetworkImage(widget.card.img!),
                fit: BoxFit.fill,
              ),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(12.0),
            child: Text(
              widget.card.titul!,
              style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(10.0),
            child: DescriptionTextWidget(text: widget.card.desc!),
          )
        ],
      ),
    );
  }
}

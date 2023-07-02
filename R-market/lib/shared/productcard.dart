// ignore_for_file: must_be_immutable

import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:r_market/models/basketproduct.dart';
import 'package:r_market/models/product.dart';

class ProductCard extends StatefulWidget {
  ProductCard({super.key, this.product});

  final Product? product;
  late BasketProduct? baskprod = BasketProduct();

  @override
  State<ProductCard> createState() => _ProductCardState();
}

class _ProductCardState extends State<ProductCard> {
  bool flag = true;
  int count = 0;
  List<Product> tempProduct = <Product>[];
  @override
  Widget build(BuildContext context) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(crossAxisAlignment: CrossAxisAlignment.end, children: [
          ListTile(
            leading: Image.network(
              widget.product!.src!,
              errorBuilder: (context, error, stackTrace) =>
                  const Text("no image"),
            ),
            title: Text(widget.product!.titul ?? ''),
            subtitle: Text(widget.product!.sub ?? ''),
          ),
          Text(
            "${widget.product!.price} Р",
            textAlign: TextAlign.right,
            style: const TextStyle(fontSize: 18),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
              Container(
                child: flag
                    ? Row(
                        children: [
                          IconButton(
                              onPressed: () {
                                setState(() {
                                  count -= 1;
                                });
                              },
                              icon: const Icon(Icons.remove)),
                          Text(count.toString()),
                          IconButton(
                              onPressed: () {
                                setState(() {
                                  count += 1;
                                });
                              },
                              icon: const Icon(Icons.add)),
                          ElevatedButton(
                              onPressed: () {
                                setState(() {
                                  // print(widget.product!.toFirestore().toString());
                                  // baskprod!.count = cout.toString();

                                  print(widget.product!.id);
                                  print(widget.product!.price!);
                                  print(widget.product!);
                                  flag = !flag;

                                  context.read<BasketProduct>().addProduct(
                                      count,
                                      widget.product!.price! * count,
                                      widget.product!,
                                      widget.product!.id!);
                                  // baskprod!.idproduct = widget.product!.id;

                                  /// нужно посмотреть что такое чистаяя архетикрура
                                  /// написать сервис который будет добавлять и удалять объекты создание репозитория см студенторг
                                });
                              },
                              style: const ButtonStyle(
                                  backgroundColor:
                                      MaterialStatePropertyAll(Colors.green)),
                              child: const Text("В корзину")),
                        ],
                      )
                    : const Text(
                        "Добавлен",
                        style: TextStyle(color: Colors.blue, fontSize: 20),
                      ),
              )
            ],
          )
        ]),
      ),
    );
  }
}

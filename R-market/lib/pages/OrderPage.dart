import 'package:flutter/material.dart';
import 'package:r_market/models/orderproduct.dart';

import '../models/product.dart';

class OrderPage extends StatelessWidget {
  List<OrderProduct> basketProductList;
  OrderPage({
    Key? key,
    required this.basketProductList,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          backgroundColor: const Color.fromRGBO(130, 209, 226, 1),
          title: const Text('Страница заказа'),
        ),
        body: ListView.builder(
            scrollDirection: Axis.vertical,
            itemCount: basketProductList.length,
            itemBuilder: (context, index) => Column(
                  crossAxisAlignment: CrossAxisAlignment.end,
                  children: [
                    Card(
                      child: ListTile(
                        leading: Image.network(
                          basketProductList[index].src!,
                          errorBuilder: (context, error, stackTrace) =>
                              const Text("no image"),
                        ),
                        title: Text("${basketProductList[index].titul}" ?? ''),
                        subtitle: Text(
                          "${basketProductList[index].count_order_product}шт ${basketProductList[index].price}Р",
                          textAlign: TextAlign.right,
                          style: const TextStyle(fontSize: 18),
                        ),
                      ),
                    ),
                  ],
                )));
  }
}

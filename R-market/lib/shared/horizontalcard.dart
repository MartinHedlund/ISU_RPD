// ignore_for_file: prefer_const_constructors

import 'package:flutter/material.dart';
import 'package:r_market/models/product.dart';

class HorizontalCardWidget extends StatefulWidget {
  const HorizontalCardWidget({super.key, this.products});

  final Product? products;

  @override
  State<HorizontalCardWidget> createState() => _HorizontalCardWidgetState();
}

class _HorizontalCardWidgetState extends State<HorizontalCardWidget> {
  bool? flag = false;
  var firstHalf;
  @override
  void initState() {
    super.initState();

    if (widget.products!.sub!.length > 50) {
      firstHalf = "${widget.products!.sub!.substring(0, 50)} ...";
    } else {
      firstHalf = widget.products!.sub!;
    }
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsetsDirectional.all(8.0),
      width: 160,
      height: 250,
      decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(25),
          color: Colors.white,
          border: Border.all(color: Color.fromARGB(36, 97, 75, 75))),
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          mainAxisSize: MainAxisSize.max,
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [
            widget.products!.src != null
                ? SizedBox(height: 100, child: _imgcard(widget.products!.src!))
                : Icon(
                    Icons.image_not_supported_outlined,
                    size: 100,
                  ),
            Text(
              widget.products?.titul ?? "NoN title",
              style: TextStyle(
                fontFamily: 'Poppins',
                fontSize: 14,
                fontWeight: FontWeight.bold,
              ),
            ),
            Text(
              firstHalf ?? "NoN desc",
              style: TextStyle(
                fontFamily: 'Poppins',
                color: Colors.grey.shade400,
                fontSize: 12,
              ),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(vertical: 8),
              child: Row(
                mainAxisSize: MainAxisSize.max,
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Text(
                    "${widget.products?.price.toString()} р",
                    style: TextStyle(
                      fontFamily: 'Poppins',
                      fontSize: 18,
                      fontWeight: FontWeight.w800,
                    ),
                  ),
                  ElevatedButton(
                    style: ButtonStyle(
                      padding: MaterialStatePropertyAll(EdgeInsets.all(13.0)),
                      shape: MaterialStateProperty.all<CircleBorder>(
                        CircleBorder(),
                      ),
                      backgroundColor: MaterialStatePropertyAll(Colors.green),
                    ),
                    onPressed: () {},
                    child: Icon(
                      Icons.add,
                      size: 20,
                    ),
                  ),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}

Widget _imgcard(String url) {
  try {
    return Image(
      errorBuilder: (context, error, stackTrace) => Text("non image"),
      image: NetworkImage(url),
      fit: BoxFit.cover,
      loadingBuilder: (BuildContext context, Widget child,
          ImageChunkEvent? loadingProgress) {
        if (loadingProgress == null) {
          return child;
        }
        return Center(
            child: Column(
          children: [
            const SizedBox(height: 10),
            CircularProgressIndicator(
              value: loadingProgress.expectedTotalBytes != null
                  ? loadingProgress.cumulativeBytesLoaded /
                      loadingProgress.expectedTotalBytes!
                  : null,
            ),
            const SizedBox(height: 10),
            Text(
                "${loadingProgress.expectedTotalBytes != null ? ((loadingProgress.cumulativeBytesLoaded / loadingProgress.expectedTotalBytes!) * 100).toStringAsFixed(2) : "Загрузка..."} %"),
          ],
        ));
      },
    );
  } catch (e) {
    return const ClipRRect(
      child: Icon(Icons.error_outline),
    );
  }
}

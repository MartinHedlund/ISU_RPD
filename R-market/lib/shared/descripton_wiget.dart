import 'package:flutter/material.dart';

// класс для сокращение описания
class DescriptionTextWidget extends StatefulWidget {
  const DescriptionTextWidget({super.key, required this.text});
  final String text;

  @override
  _DescriptionTextWidgetState createState() => _DescriptionTextWidgetState();
}

class _DescriptionTextWidgetState extends State<DescriptionTextWidget> {
  late String firstHalf;
  late String secondHalf;

  bool flag = true;

  @override
  void initState() {
    super.initState();

    if (widget.text.length > 50) {
      firstHalf = widget.text.substring(0, 50);
      secondHalf = widget.text.substring(50, widget.text.length);
    } else {
      firstHalf = widget.text;
      secondHalf = "";
    }
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: secondHalf.isEmpty
          ? Text(
              firstHalf,
              style: Theme.of(context).textTheme.titleSmall,
            )
          : Column(
              children: <Widget>[
                GestureDetector(
                  onTap: () => setState(() {
                    flag = !flag;
                  }),
                  child: Text(
                    flag
                        ? ("$firstHalf \n...развернуть")
                        : (firstHalf + secondHalf),
                    style: Theme.of(context).textTheme.titleSmall,
                  ),
                ),
              ],
            ),
    );
  }
}

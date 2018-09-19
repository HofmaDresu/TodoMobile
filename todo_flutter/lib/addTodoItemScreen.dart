import 'package:flutter/material.dart';

class AddTodoItemScreen extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => new _AddTodoItemScreenState();
}

class _AddTodoItemScreenState extends State<AddTodoItemScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(title: Text("Add Todo Item")),
        body: Container(
          padding: EdgeInsets.all(16.0),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: <Widget>[
              TextFormField(decoration: InputDecoration(labelText: "Todo Name")),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: <Widget>[
                  RaisedButton(
                    child: Text("Cancel"),
                    onPressed: () {
                      Navigator.pop(context);
                    },
                  ),
                  RaisedButton(
                    child: Text("Save"),
                    onPressed: () {
                      //TODO: Save
                      Navigator.pop(context);
                    },
                  )
                ],
              )
            ],
          )
        )
      );
  }
}

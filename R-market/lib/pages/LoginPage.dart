import 'package:flutter/material.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:r_market/pages/RegisterPage.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final _formKey = GlobalKey<FormState>();
  final FirebaseAuth _auth = FirebaseAuth.instance;
  late String _email, _password;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Авторизация'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              TextFormField(
                decoration: const InputDecoration(labelText: 'Email'),
                validator: (value) =>
                    value!.isEmpty ? 'Пожалуйста, введите email' : null,
                onSaved: (value) => _email = value!.trim(),
              ),
              TextFormField(
                decoration: const InputDecoration(labelText: 'Пароль'),
                validator: (value) =>
                    value!.isEmpty ? 'Пожалуйста, введите пароль' : null,
                obscureText: true,
                onSaved: (value) => _password = value!.trim(),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(vertical: 16.0),
                child: ElevatedButton(
                  onPressed: () async {
                    if (_formKey.currentState!.validate()) {
                      _formKey.currentState!.save();
                      try {
                        final User? user =
                            (await _auth.signInWithEmailAndPassword(
                                    email: _email, password: _password))
                                .user;

                        // ignore: use_build_context_synchronously
                        Navigator.pushReplacementNamed(context, '/home');
                      } catch (e) {
                        print(e.toString());
                      }
                    }
                  },
                  child: const Text('Войти'),
                ),
              ),
              Padding(
                  padding: const EdgeInsets.symmetric(vertical: 8.0),
                  child: TextButton(
                    child: const Text("Регистрация"),
                    onPressed: () => Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => const RegisterPage())),
                  )),
            ],
          ),
        ),
      ),
    );
  }
}

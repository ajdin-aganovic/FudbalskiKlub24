

import 'package:afk_android/models/korisnik.dart';

import 'base_provider.dart';

class KorisnikProvider extends BaseProvider<Korisnik>{

  KorisnikProvider():super("Korisnik");

  @override
  Korisnik fromJson(data) {
    // TODO: implement fromJson
    return Korisnik.fromJson(data);
  }

}
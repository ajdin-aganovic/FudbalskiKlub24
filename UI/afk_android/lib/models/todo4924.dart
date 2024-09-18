
  import 'package:json_annotation/json_annotation.dart';
part 'todo4924.g.dart';

@JsonSerializable()
class ToDo4924{
  int? todo4924id ;

String? nazivaktivnosti;

String? opisaktivnosti;
int? korisnikid;
DateTime? datumzavrsenja;
String? statemachine;


  ToDo4924(this.todo4924id, this.nazivaktivnosti, this.opisaktivnosti, this.korisnikid, this.datumzavrsenja, this.statemachine);
  // factory Korisnici.fromJson(Map<String,dynamic>json)=>_$KorisniciFromJson(json);

  factory ToDo4924.fromJson(Map<String,dynamic>json)=>_$ToDo4924FromJson(json);
  Map<String,dynamic>toJson()=>_$ToDo4924ToJson(this);
}
import 'package:json_annotation/json_annotation.dart';
part 'todo4924.g.dart';

@JsonSerializable()
class ToDo4924{
  int? todo4924id;

String? nazivaktivnosti;

String? opisaktivnosti;
  DateTime? datumzavrsenja;

int? korisnikid;

String? statemachine;


  ToDo4924(this.todo4924id, this.nazivaktivnosti, this.opisaktivnosti,this.datumzavrsenja, this.korisnikid, this.statemachine);
  // factory Korisnici.fromJson(Map<String,dynamic>json)=>_$KorisniciFromJson(json);

  factory ToDo4924.fromJson(Map<String,dynamic>json)=>_$ToDo4924FromJson(json);
  Map<String,dynamic>toJson()=>_$ToDo4924ToJson(this);
}
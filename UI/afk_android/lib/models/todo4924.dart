import 'package:json_annotation/json_annotation.dart';
part 'todo4924.g.dart';

@JsonSerializable()
class ToDo4924{
   int? todo4924Id;
  String? nazivAktivnosti;
  String? opisAktivnosti;
  DateTime? datumZavrsenja;
  int? korisnikId;
  String? stateMachine;


  ToDo4924(this.todo4924Id, this.nazivAktivnosti, this.opisAktivnosti, this.datumZavrsenja, this.korisnikId, this.stateMachine);
  // factory Korisnici.fromJson(Map<String,dynamic>json)=>_$KorisniciFromJson(json);

  factory ToDo4924.fromJson(Map<String,dynamic>json)=>_$ToDo4924FromJson(json);
  Map<String,dynamic>toJson()=>_$ToDo4924ToJson(this);
}

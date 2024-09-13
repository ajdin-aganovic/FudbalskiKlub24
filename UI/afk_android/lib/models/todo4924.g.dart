// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'todo4924.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ToDo4924 _$ToDo4924FromJson(Map<String, dynamic> json) =>
    ToDo4924(
      json['todo4924Id'] as int?,
      json['nazivAktivnosti'] as String?,
      json['opisAktivnosti'] as String?,
      json['datumZavrsenja'] == null
          ? null
          : DateTime.parse(json['datumZavrsenja'] as String),
      json['korisnikId'] as int?,
      json['stateMachine'] as String?,
    );

Map<String, dynamic> _$ToDo4924ToJson(ToDo4924 instance) =>
    <String, dynamic>{
      'todo4924Id': instance.todo4924Id,
      'nazivAktivnosti': instance.nazivAktivnosti,
      'opisAktivnosti': instance.opisAktivnosti,
      'datumZavrsenja': instance.datumZavrsenja,
      'korisnikId': instance.korisnikId,
      'stateMachine': instance.stateMachine,
    };

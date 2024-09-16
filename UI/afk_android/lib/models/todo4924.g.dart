// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'todo4924.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ToDo4924 _$ToDo4924FromJson(Map<String, dynamic> json) => ToDo4924(
      json['todo4924id'] as int?,
      json['nazivaktivnosti'] as String?,
      json['opisaktivnosti'] as String?,
            json['datumzavrsenja'] == null
          ? null
          : DateTime.parse(json['datumzavrsenja'] as String),
      json['korisnikid'] as int?,
      json['statemachine'] as String?
    );

Map<String, dynamic> _$ToDo4924ToJson(ToDo4924 instance) => <String, dynamic>{
      'todo4924id': instance.todo4924id,
      'nazivaktivnosti': instance.nazivaktivnosti,
      'opisaktivnosti': instance.opisaktivnosti,
      'datumzavrsenja': instance.datumzavrsenja,
      'korisnikid': instance.korisnikid,
      'statemachine': instance.statemachine,
    };

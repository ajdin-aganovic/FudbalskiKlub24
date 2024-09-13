

import 'package:afk_android/models/todo4924.dart';

import 'base_provider.dart';

class ToDo4924Provider extends BaseProvider<ToDo4924>{

  ToDo4924Provider():super("ToDo4924");

  @override
  ToDo4924 fromJson(data) {
    // TODO: implement fromJson
    return ToDo4924.fromJson(data);
  }

  // List<ToDo4924> allowedActions([int? id]) {
  //     var url = Uri.parse("https://10.0.2.2:7181/allowedActions/$id");

  //     Map<String, String> headers = createHeaders();

  //     var response = http!.get(url, headers: headers);

  //     if (isValidResponse(response)) {
  //       var data = jsonDecode(response.body);
  //       return data.map((x) => fromJson(x)).cast<ToDo4924>().toList();
  //     } else {
  //       throw Exception("Exception... handle this gracefully");
  //     }
  //   }
}


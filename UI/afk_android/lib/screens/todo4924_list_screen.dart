import 'package:afk_android/models/search_result.dart';
import 'package:afk_android/providers/cart_provider.dart';
import 'package:afk_android/providers/korisnik_provider.dart';
import 'package:afk_android/providers/todo4924_provider.dart';
import 'package:afk_android/screens/todo4924_details_screen.dart';
import 'package:afk_android/screens/todo4924_list_screen.dart';
import 'package:afk_android/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../models/korisnik.dart';
import '../models/todo4924.dart';
import '../utils/util.dart';

class ToDo4924ListScreen extends StatefulWidget {
  static const String routeName = "/todo4924";

  Korisnik?korisnik;
  ToDo4924ListScreen({this.korisnik, super.key});

  @override
  State<ToDo4924ListScreen> createState() => _ToDo4924ListScreen();
}

class _ToDo4924ListScreen extends State<ToDo4924ListScreen> {
  ToDo4924Provider? _todo4924Provider=null;
  SearchResult<ToDo4924>? result=null;

KorisnikProvider? _korisnikProvider=null;
  SearchResult<Korisnik>? korisnikResult=null;

String? izabraniStatus;
String? izabraniKorisnikId;

  final TextEditingController _nazivController=TextEditingController();
  final TextEditingController _sifraController=TextEditingController();
  final TextEditingController _datumController=TextEditingController();

  final ScrollController _horizontal = ScrollController(),
      _vertical = ScrollController();


  // @override void didChangeDependencies() {
  //   // TODO: implement didChangeDependencies
  //   super.didChangeDependencies();
  //   _todo4924Provider=context.read<ToDo4924Provider>();
  // }

  Future loadData()async
  {
    var tmpData = await _todo4924Provider?.get();
    var tmpData1 = await _korisnikProvider?.get();
    setState(() {
      if(tmpData!=null) {
        result = tmpData!;
      } else {
        result = null;
      }

      if(tmpData1!=null) {
        korisnikResult=tmpData1!;
      } else {
        korisnikResult=null;
      }
    });
  }

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _todo4924Provider = context.read<ToDo4924Provider>();
    _korisnikProvider = context.read<KorisnikProvider>();
    print("pozvan initState");
    loadData();
  }

  
  String getKorisnickoIme(int id)
  {
    var pronadjeniKorisnik=korisnikResult?.result.firstWhere((element) => element.korisnikId==id);
    // String? pronadjenoIme=_korisnikResult?.result.firstWhere((element) => element.korisnikId==id).korisnickoIme??"Nije pronađeno";
    String? pronadjenoIme="${pronadjeniKorisnik!.ime} ${pronadjeniKorisnik.prezime} - ${pronadjeniKorisnik.korisnickoIme}"??"Nije pronađeno";
    return pronadjenoIme;
  }

  List<String>sviStatusi()
  {
    var lista=['U toku', 'Realizirana', 'Istekla'];
    return lista;
  }

  List<Korisnik>sviKorisnici()
  {
    var lista=korisnikResult?.result;
    return lista??[];
  }


  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title_widget: const Text("Lista aktivnosti"),
      child: 
      SingleChildScrollView(child: 
      Container(child: 
      Column(children: [
        _buildSearch(),
        Container(
          height: 500,
          child: GridView(
            gridDelegate: 
            const SliverGridDelegateWithFixedCrossAxisCount(
              crossAxisCount: 2,
              childAspectRatio: 4/3,
              crossAxisSpacing: 10,
              mainAxisSpacing: 30),
              scrollDirection: Axis.horizontal,
              children: _buildProductCardList(),
          ),
        )
      ],),),)
      // Container(
      //   child: Column(children: [
      //     _buildSearch(),
      //     _buildDataListView(),
      //   ],),
      // )
    );
  }

  List<Widget> _buildProductCardList() {
    if (result?.result?.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget>? list = result?.result.map((x) =>
     Container(
      child: Column(
        children: [
          Container(
            height: 100,
            width: 100,
          ),
          Text(x.nazivaktivnosti ?? ""),
          Text(x.opisaktivnosti??""),
          Text(getKorisnickoIme(x.korisnikid!)??"not set"),
          Text(DateFormat('dd.MM.yyyy').format(x.datumzavrsenja!)??"nije postavljeno"),
          
          IconButton(onPressed: () {
            
              Navigator.of(context).push(
                MaterialPageRoute(builder: (context)=> ToDo4924EditableScreen(todo4924: x,)
                )
              );
            
          }, icon:const Icon(Icons.edit))
        ],
      ),
    )).cast<Widget>().toList()??[];
    
    return list;
  }

  Widget _buildSearch(){
    return Padding(
      padding: const EdgeInsets.all(12.0),
      child: 
      Column(mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [

            Row(
              children: [
                Expanded(
                  child: 
                  DropdownButtonFormField<String>(
                      value: izabraniStatus,
                      decoration: const InputDecoration(labelText: 'Status'),
                      items: 
                      sviStatusi().map(
                        (e)=>DropdownMenuItem<String>(
                          child: Text(e), 
                          value: e,)
                          ).toList(),
                      onChanged: (value) {
                        izabraniStatus=value;
                      },
                      validator: (value) {
                        if (value == null) {
                          return 'Molimo Vas unesite kategoriju proizvoda';
                        }
                        return null;
                      },
                    ),
                ),
                
                Expanded(
                  child: 
                  DropdownButtonFormField<String>(
                      value: izabraniKorisnikId,
                      decoration: const InputDecoration(labelText: 'Korisnik'),
                      items: 
                      sviKorisnici().map(
                        (e)=>DropdownMenuItem<String>(
                          child: Text(e.korisnickoIme??"Not set"), 
                          value: e.korisnikId.toString(),)
                          ).toList(),
                      onChanged: (value) {
                        izabraniKorisnikId=value;
                      },
                      validator: (value) {
                        if (value == null) {
                          return 'Molimo Vas unesite kategoriju proizvoda';
                        }
                        return null;
                      },
                    ),
                  
                ),
                
                Expanded(
                  child: 
                  TextField(
                      decoration: 
                      const InputDecoration(labelText: "Datum", ), 
                      controller:_datumController,
                    ),
                ),
              ],
            ),
            
            Row(
              children: [
                ElevatedButton(onPressed:() async{
                    
                var data=await _todo4924Provider!.get(
                  filter: {
                    'korisnikid':izabraniKorisnikId,
                    'statemachine':izabraniStatus
                    ,'datumzavrsenja':_datumController.text
                  }
                );
                        
                setState(() {
                  result=data??null;
                  
                });
                }, 
                child: const Text("Učitaj podatke")),

                ElevatedButton(onPressed:() async{
                    
                Navigator.of(context).push(
                          MaterialPageRoute(
                          builder: (context) => ToDo4924EditableScreen(),
                              ),
                              );
                }, 
                child: const Text("Dodaj")),
              ],
            ),
        ],
      ),
    
    );
  }

}
 
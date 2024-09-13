  import 'dart:math';

import 'package:afk_android/models/search_result.dart';
  import 'package:afk_android/providers/cart_provider.dart';
  import 'package:afk_android/providers/korisnik_provider.dart';
  import 'package:afk_android/providers/todo4924_provider.dart';
  import 'package:afk_android/screens/todo4924_screen.dart';
  // import 'package:afk_android/screens/ToDo4924_editable_screen.dart';
  import 'package:afk_android/screens/todo4924novi_screen.dart';
  import 'package:afk_android/widgets/master_screen.dart';
  import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
  import 'package:intl/intl.dart';
  import 'package:provider/provider.dart';

  import '../models/korisnik.dart';
  import '../models/todo4924.dart';
  import '../utils/util.dart';


  class ToDo4924ListScreen extends StatefulWidget {
    static const String routeName = "/ToDo4924";

    Korisnik?korisnik;
    ToDo4924ListScreen({super.key});

    @override
    State<ToDo4924ListScreen> createState() => _ToDo4924ListScreen();
  }

  class _ToDo4924ListScreen extends State<ToDo4924ListScreen> {
    ToDo4924Provider? _ToDo4924Provider=null;
    SearchResult<ToDo4924>? result=null;
    KorisnikProvider? _korisnikProvider=null;
    SearchResult<Korisnik>? resultKorisnik=null;
    final TextEditingController _korisnikController=TextEditingController();
    final TextEditingController _datumController=TextEditingController();
    final TextEditingController _statusController=TextEditingController();

    String? _selectedStatus;
    String? _selectedKorisnik;

    final ScrollController _horizontal = ScrollController(),
        _vertical = ScrollController();

    Future loadData()async
    {
      var tmpData = await _ToDo4924Provider?.get();
      var tmpDataKorisnik = await _korisnikProvider?.get();
      setState(() {
        if(tmpData!=null)
          result = tmpData;
        else
          result = null;
        
        if(tmpDataKorisnik!=null)
          resultKorisnik=tmpDataKorisnik;
        else
          resultKorisnik=null;
      });
    }

    @override
    void initState() {
      // TODO: implement initState
      super.initState();
      _ToDo4924Provider = context.read<ToDo4924Provider>();
      _korisnikProvider=context.read<KorisnikProvider>();
      print("pozvan initState");
      loadData();
    }

    String? getKorisnikDetails(int? id)
    {
      var pronadjeniRacun=resultKorisnik?.result.firstWhere((element) => element.korisnikId==id);
      if(pronadjeniRacun==null) {
        return "Greška. Nema takvog računa";
      } else
      {
        String? pronadjeniBrojRacuna="${pronadjeniRacun.ime} ${pronadjeniRacun.prezime}"??"Nije pronađen";
        return pronadjeniBrojRacuna;
      }
    }

    List<String> stateMachineVrijednosti(){
      var lista=['U toku', 'Realizovana', 'Istekla'];
      return lista;
    }

    List<Korisnik> korisnikVrijednosti()
    {
      var lista=resultKorisnik?.result;
      return lista??[];
    }


    @override
    Widget build(BuildContext context) {
      return MasterScreenWidget(
        title_widget: const Text("Lista ToDo4924a"),
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
        ],
        ),
        ),
        )
      );
    }

    List<Widget> _buildProductCardList() {
      if (result?.result?.length == 0) {
        return [Text("Loading...")];
      }

      

      List<Widget>? list = result?.result.map((x) =>
      
      Column(
        children: [
          const SizedBox(
              height: 10,
              width: 10,
          ),
          Text(x.nazivAktivnosti ?? ""),
          Text(x.opisAktivnosti.toString()??""),
          Text(
            DateFormat('dd.MM.yyyy').format(x.datumZavrsenja!??DateTime.now())
          ),
          Text(x.korisnikId!.toString()),
            IconButton(onPressed: () {
            
              Navigator.of(context).push(
                MaterialPageRoute(builder: (context)=> ToDo4924DetailsScreen(todo4924: x,)
                )
              );
            
          }, icon:const Icon(Icons.edit))
                  ],
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
                        decoration: const InputDecoration(labelText: 'Korisnik'),
                        value: _korisnikController.text.isNotEmpty ? _korisnikController.text : null,
                        items:
                          korisnikVrijednosti().map((Korisnik value) {
                              return DropdownMenuItem<String>(
                                value: value.korisnikId.toString()??'1',
                                child: Text(value.korisnickoIme??"ajdo"),
                              );
                            })
                            .toList(),

                        onChanged: (value) {
                          setState(() {
                            _selectedKorisnik=value!;
                            print("Odabrani $value");
                          });
                        },
                        validator: (value) {
                          if (value == null) {
                            return 'Molimo Vas, unesite ispravnog Korisnika';
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

                  Expanded(
                  child: DropdownButtonFormField<String>(
                    decoration: const InputDecoration(labelText: "Status"),
                    value: _selectedStatus,
                    items: stateMachineVrijednosti()
                        .map((String value) {
                          return DropdownMenuItem<String>(
                            value: value,
                            child: Text(value),
                          );
                        })
                        .toList(),
                    onChanged: (newValue) {
                      setState(() {
                        _selectedStatus = newValue;
                      });
                    },
                  ),
                  ),
                
                ],
              ),
              
              Row(
                children: [
                  ElevatedButton(onPressed:() async{
                      
                  var data=await _ToDo4924Provider!.get(
                    filter: {
                      // 'ToDoKorisnikId':_korisnikController.text, 
                      'ToDoKorisnikId':_selectedKorisnik,
                      'ToDoDatumZavrsenja':_datumController.text,
                      'ToDoStateMachine':_selectedStatus
                    }
                  );
                  for (var element in data.result) {
                    print(getKorisnikDetails(element.korisnikId));
                  }
                          
                  setState(() {
                    result=data??null;
                  });
                  }, 
                  child: const Text("Učitaj podatke")),
                  
                  ElevatedButton(onPressed:() async{
                    
                    Navigator.of(context).push(
                    MaterialPageRoute(
                    builder: (context) => ToDo4924DetailsScreen()
                    ),
                    );
                             
                  }, 
                  child: const Text("Dodaj ToDo4924"),
                  ),
                ],
              ),
          ],
        ),
      
      );
    }

  Widget _buildDataListView() {
    return 
      Scrollbar(
        controller: _vertical,
        thumbVisibility: true,
        trackVisibility: true,
        child: Scrollbar(
          controller: _horizontal,
          thumbVisibility: true,
          trackVisibility: true,
          notificationPredicate: (notif) => notif.depth == 1,
          child: SingleChildScrollView(
            controller: _vertical,
            scrollDirection: Axis.vertical,
            child: SingleChildScrollView(
              controller: _horizontal,
              scrollDirection: Axis.horizontal,
              child: 
              DataTable(
                  columns: const [
                      DataColumn(label: Expanded(
                      child: Text("ToDo4924 ID",
                      style: TextStyle(fontStyle: FontStyle.italic),),
                      
                      ),
                      ),

                      DataColumn(label: Expanded(
                      child: Text("Naziv aktivnosti ToDo4924a",
                      style: TextStyle(fontStyle: FontStyle.italic),),
                      ),
                      ),

                      DataColumn(label: Expanded(
                      child: Text("Opis aktivnosti ToDo4924a",
                      style: TextStyle(fontStyle: FontStyle.italic),),
                      ),
                      ),

                      DataColumn(label: Expanded(
                      child: Text("Datum zavrsenja ToDo4924a",
                      style: TextStyle(fontStyle: FontStyle.italic),),
                      ),
                      ),

                      DataColumn(label: Expanded(
                      child: Text("Status ToDo4924a",
                      style: TextStyle(fontStyle: FontStyle.italic),),
                      ),
                      ),

                      DataColumn(label: Expanded(
                      child: Text("Ime i prezime korisnika",
                      style: TextStyle(fontStyle: FontStyle.italic),),
                      ),
                      ),


                      ],

                rows: 
                  result?.result.map((ToDo4924 e) => DataRow(
                    onSelectChanged: (yxc)=>{
                      if((Authorization.ulogaKorisnika=="Administrator")&&yxc==true)
                        {
                          print('odabrani: ${e.todo4924Id}'),
                        
                        }
                      else
                      {
                        print('odabrani: ${e.todo4924Id}'),
                          Navigator.of(context).push(
                            MaterialPageRoute(builder: (context)=> ToDo4924DetailsScreen(todo4924: e,)
                            )
                        ) 
                      }
                    },
                    cells: [
                    DataCell(Text(e.todo4924Id.toString()??"0")),
                    DataCell(Text(e.nazivAktivnosti??"nema upisa")),
                    DataCell(Text(e.opisAktivnosti??"nema upisa")),
                    DataCell(Text(e.datumZavrsenja?.toIso8601String()??"")),
                    DataCell(Text(e.stateMachine.toString()??"nema upisa")),
                    DataCell(Text(getKorisnikDetails(e.korisnikId)??"nema upisa")),

                    ]
                  )).toList()??[]
                
                ),
            ),
          ),
        ),
    );
  }
  }
  
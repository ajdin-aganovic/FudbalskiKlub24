  import 'dart:math';

import 'package:afk_android/models/search_result.dart';
  import 'package:afk_android/providers/cart_provider.dart';
  import 'package:afk_android/providers/korisnik_provider.dart';
  import 'package:afk_android/providers/todo4924_provider.dart';
  import 'package:afk_android/screens/todo4924_list_screen.dart';
  import 'package:afk_android/screens/todo4924_details.dart';
  import 'package:afk_android/widgets/master_screen.dart';
  import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
  import 'package:intl/intl.dart';
  import 'package:provider/provider.dart';

  import '../models/korisnik.dart';
  import '../models/todo4924.dart';
  import '../utils/util.dart';

// class ToDo4924ListScreen extends StatefulWidget {
//   static const String routeName = "/ToDo4924";

//   Korisnik?korisnik;
//   ToDo4924ListScreen({this.korisnik, super.key});

//   @override
//   State<ToDo4924ListScreen> createState() => _ToDo4924ListScreen();
// }

// class _ToDo4924ListScreen extends State<ToDo4924ListScreen> {
//   ToDo4924Provider? _todo4924Provider=null;
//   SearchResult<ToDo4924>? result=null;
  
//   KorisnikProvider? _korisnikProvider=null;
//   SearchResult<Korisnik>? korisnikResult=null;

//   String? _izabraniStatus;
//   String? izabraniKorisnikId;
//   String? izabraniDatum=DateTime.now().toIso8601String().substring(0,10);
  
//   final TextEditingController _nazivController=TextEditingController();
//   final TextEditingController _sifraController=TextEditingController();
//   final TextEditingController _datumZavrsenjaController=TextEditingController();

//   final ScrollController _horizontal = ScrollController(),
//       _vertical = ScrollController();


//   // @override void didChangeDependencies() {
//   //   // TODO: implement didChangeDependencies
//   //   super.didChangeDependencies();
//   //   _todo4924Provider=context.read<ToDo4924Provider>();
//   // }

//   Future loadData()async
//   {
//     var tmpData = await _todo4924Provider?.get();
//     var tmpData1 = await _korisnikProvider?.get();
//     setState(() {
//       // result = tmpData!;
//       // korisnikResult = tmpData1!;

//       if(tmpData!=null)
//           result = tmpData;
//         else
//           result = null;
        
//         if(tmpData1!=null)
//           korisnikResult=tmpData1;
//         else
//           korisnikResult=null;
//     });
//   }

  

//   @override
//   void initState() {
//     // TODO: implement initState
//     super.initState();
//     _todo4924Provider = context.read<ToDo4924Provider>();
//     _korisnikProvider = context.read<KorisnikProvider>();
//     print("pozvan initState");
//     loadData();
//   }

//   String getKorisnickoIme(int id)
//   {
//     var pronadjeniKorisnik=korisnikResult?.result.firstWhere((element) => element.korisnikId==id);
//     if(pronadjeniKorisnik==null)
//     return '';
//     // String? pronadjenoIme=_korisnikResult?.result.firstWhere((element) => element.korisnikId==id).korisnickoIme??"Nije pronađeno";
//     String? pronadjenoIme="${pronadjeniKorisnik!.ime} ${pronadjeniKorisnik.prezime} - ${pronadjeniKorisnik.korisnickoIme}"??"Nije pronađeno";
//     return pronadjenoIme;
//   }


//   @override
//   Widget build(BuildContext context) {
//     return MasterScreenWidget(
//       title_widget: const Text("Lista todo4924a"),
//       child: 
//       SingleChildScrollView(child: 
//       Container(child: 
//       Column(children: [
//         _buildSearch(),
//         Container(
//           height: 500,
//           child: GridView(
//             gridDelegate: 
//             const SliverGridDelegateWithFixedCrossAxisCount(
//               crossAxisCount: 2,
//               childAspectRatio: 4/3,
//               crossAxisSpacing: 10,
//               mainAxisSpacing: 30),
//               scrollDirection: Axis.horizontal,
//               children: _buildProductCardList(),
//           ),
//         )
//       ],),),)
//       // Container(
//       //   child: Column(children: [
//       //     _buildSearch(),
//       //     _buildDataListView(),
//       //   ],),
//       // )
//     );
//   }

//   List<Korisnik> sviKorisnici()
//   {
//     var listaKorisnika=korisnikResult?.result;


//     return listaKorisnika??[];

//   }

//   List<String> sviStatusi()
//   {
//     var lista=['U toku', 'Realizirana', 'Istekla'];
//     return lista;
//   }

//   List<Widget> _buildProductCardList() {
//     if (result?.result?.length == 0) {
//       return [Text("Loading...")];
//     }

//     List<Widget>? list = result?.result.map((x) =>
//      Container(
//       child: Column(
//         children: [
//           Container(
//             height: 100,
//             width: 100,
//           ),
//           Text(x.nazivaktivnosti ?? ""),
//           Text(x.opisaktivnosti??""),
//           Text(getKorisnickoIme(x.korisnikid!)??""),
//           Text(DateFormat('dd.MM.yyyy').format(x.datumzavrsenja!)??DateFormat('dd.MM.yyyy').format(DateTime.now())),
          
//           IconButton(onPressed: () {
            
//               Navigator.of(context).push(
//                 MaterialPageRoute(builder: (context)=> ToDo4924EditableScreen(todo4924: x,)
//                 )
//               );
           
//           }, icon:const Icon(Icons.edit))
//         ],
//       ),
//     )).cast<Widget>().toList()??[];
    
//     return list;
//   }

//   Widget _buildSearch(){
//     return Padding(
//       padding: const EdgeInsets.all(12.0),
//       child: 
//       Column(
//         // mainAxisAlignment: MainAxisAlignment.spaceEvenly,
//         children: [

//             Row(
//               children: [
//                 Expanded(
//                   child:
//                    DropdownButtonFormField(
                                
//                     decoration: const InputDecoration(labelText: 'Korisnik'),
//                     value: _izabraniStatus,
//                     items: 
//                     List<DropdownMenuItem>.from(
//                       sviKorisnici().map(
//                         (Korisnik? e) => DropdownMenuItem<String>(
//                           value: e?.korisnikId.toString()??"1",
//                           child: Text("${e?.korisnickoIme}"??"not set"),
//                           )).toList()),
                  
//                     onChanged: (newValue) {
//                       setState(() {
//                         if(newValue==null)
//                           izabraniKorisnikId=null;
//                         else
//                           izabraniKorisnikId=newValue;
//                         print("Odabrani $newValue");
//                       });
//                     }
//                   ),
//                 ),
                
                
//                 Expanded(
//                   child: 
//                   TextField(
//                       decoration: 
//                       const InputDecoration(labelText: "Datum", 
//                       ), 
//                       controller:_datumZavrsenjaController,
                      
//                     ),
//                 ),
//                 // Expanded(
//                 //   child:
//                 //    DropdownButtonFormField(
                                
//                 //     decoration: const InputDecoration(labelText: 'Status'),
//                 //     value: _izabraniStatus,
//                 //     items: 
//                 //       sviStatusi().map(
//                 //         (String? e) => DropdownMenuItem<String>(
//                 //           value: e??"not set",
//                 //           child: Text(e??"not set"),
//                 //           )).toList(),
                  
//                 //     onChanged: (newValue) {
//                 //       setState(() {
//                 //         _izabraniStatus=newValue;
//                 //         print("Odabrani $newValue");
//                 //       });
//                 //     }
//                 //   ),
//                 // ),

//                 Expanded(
//                   child: DropdownButtonFormField<String>(
//                     decoration: const InputDecoration(labelText: "Status"),
//                     value: _izabraniStatus,
//                     items: sviStatusi()
//                         .map((String value) {
//                           return DropdownMenuItem<String>(
//                             value: value,
//                             child: Text(value),
//                           );
//                         })
//                         .toList(),
//                     onChanged: (newValue) {
//                       setState(() {
//                         _izabraniStatus = newValue;
//                       });
//                     },
//                   ),
//                   ),
//               ],
//             ),
            
//             Row(
//               mainAxisAlignment: MainAxisAlignment.spaceEvenly,
//               children: [
//                 ElevatedButton(onPressed:() async{
                    
//                 var data=await _todo4924Provider!.get(
//                   filter: {
//                     'korisnikid':izabraniKorisnikId, 
//                     'datumzavrsenja':_datumZavrsenjaController.text,
//                     'statemachine':_izabraniStatus,
//                   }
//                 );
                        
//                 setState(() {
//                   result=data??null;
                  
//                 });
//                 }, 
//                 child: const Text("Učitaj podatke")),

//                 ElevatedButton(onPressed: (){
                        
//                           Navigator.of(context).push(
//                           MaterialPageRoute(
//                           builder: (context) => ToDo4924EditableScreen(),
//                               ),
//                               );
//                             }, 
//                       child: const Text(
//                         'Dodaj',
//                         style: TextStyle(color: Colors.black, fontSize: 15),
//                        ),
                       
//                       ),
//               ],
//             ),
//         ],
//       ),
    
//     );
//   }
// }

// RAZGRANIČENJE




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
      var lista=['U toku', 'Realizirana', 'Istekla'];
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
          Text(x.nazivaktivnosti ?? ""),
          Text(x.opisaktivnosti.toString()??""),
          Text(
            DateFormat('dd.MM.yyyy').format(x.datumzavrsenja!??DateTime.now())
          ),
          Text(x.korisnikid!.toString()),
            IconButton(onPressed: () {
            
              Navigator.of(context).push(
                MaterialPageRoute(builder: (context)=> ToDo4924EditableScreen(todo4924: x,)
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
                      'ToDoKorisnikId':_korisnikController.text, 
                      'korisnikid':_selectedKorisnik,
                      'datumzavrsenja':_datumController.text,
                      'statemachine':_selectedStatus
                    }
                  );
                  for (var element in data.result) {
                    print(getKorisnikDetails(element.korisnikid));
                  }
                          
                  setState(() {
                    result=data??null;
                  });
                  }, 
                  child: const Text("Učitaj podatke")),
                  
                  ElevatedButton(onPressed:() async{
                    
                    Navigator.of(context).push(
                    MaterialPageRoute(
                    builder: (context) => ToDo4924EditableScreen()
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

  }
  

import 'package:afk_android/models/cart.dart';
import 'package:afk_android/models/search_result.dart';
import 'package:afk_android/providers/korisnik_provider.dart';
import 'package:afk_android/providers/todo4924_provider.dart';
import 'package:afk_android/screens/todo4924_screen.dart';
// import 'package:afk_android/screens/ToDo4924_list_screen.dart';
import 'package:afk_android/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:intl/intl.dart';

import 'package:provider/provider.dart';

import '../models/korisnik.dart';
import '../models/todo4924.dart';


class ToDo4924DetailsScreen extends StatefulWidget {
  static const String routeName = "/todo4924";

  Korisnik?korisnik;
  ToDo4924? todo4924;

  ToDo4924DetailsScreen({this.todo4924,this.korisnik, super.key});

  @override
  State<ToDo4924DetailsScreen> createState() => _ToDo4924DetailsScreen();
}

class _ToDo4924DetailsScreen extends State<ToDo4924DetailsScreen> {

  final _formKey=GlobalKey<FormBuilderState>();

  Map<String,dynamic>_initialValue={};

  late ToDo4924Provider _ToDo4924Provider;
  SearchResult<ToDo4924>? _ToDo4924Result;
  
  late KorisnikProvider _korisnikProvider;
  SearchResult<Korisnik>? _korisnikResult;
  


  @override
  void initState() {
    // TODO: implement initState
    super.initState();
  _initialValue= {
    'todo4924Id':widget.todo4924?.todo4924Id.toString()??"0",
    'korisnikId':widget.todo4924?.korisnikId.toString()??"1",
    'nazivAktivnosti':widget.todo4924?.nazivAktivnosti??"---",
    'opisAktivnosti': widget.todo4924?.opisAktivnosti??"---", 
    'datumZavrsenja': widget.todo4924?.datumZavrsenja!.toIso8601String()??DateTime.now().toIso8601String(), 
    'stateMachine': widget.todo4924?.stateMachine??"U toku", 
  };

  _ToDo4924Provider=context.read<ToDo4924Provider>(); 
  _korisnikProvider=context.read<KorisnikProvider>();
  initForm();
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();

  }

  Future initForm()async{
    _ToDo4924Result=await _ToDo4924Provider.get();
      _korisnikResult=await _korisnikProvider.get();

  }

    String getKorisnickoIme(int id)
  {
    var pronadjeniKorisnik=_korisnikResult?.result.firstWhere((element) => element.korisnikId==id);
    String? pronadjenoIme="${pronadjeniKorisnik!.ime} ${pronadjeniKorisnik.prezime} - ${pronadjeniKorisnik.korisnickoIme}"??"Nije pronađeno";
    return pronadjenoIme;
  }


  Future<ToDo4924> getToDo4924()async
  {
    ToDo4924 pronadjeni=await _ToDo4924Result!.result.first;
    return pronadjeni;
  }   

  List<String> dobaviStateMachine()
  {
    var lista =['U toku', 'Realizovana', 'Istekla'];
    return lista;
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: 'ToDo4924 ID: ${widget.todo4924?.todo4924Id??'0'}' ?? "ToDo4924 detalji",
      child: buildForm()
     
      );
  }

  FormBuilder buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
        child: Padding(
          padding: const EdgeInsets.all(10.0),
          child:
           Column(children: [
            Expanded(
              child: FormBuilderTextField (
                // readOnly: true,
                decoration: const InputDecoration(labelText: "ToDo4924 ID"), 
                readOnly: true,

                name: 'todo4924Id',
                
                    ),
            ),
          Expanded(
            child: FormBuilderTextField (
                decoration: const InputDecoration(labelText: "Naziv aktivnosti ToDo4924a"), 
                
                name: 'nazivAktivnosti',
            ),
          ),
          Expanded(
            child: FormBuilderTextField (
                decoration: const InputDecoration(labelText: "Opis aktivnosti ToDo4924a"), 
                
                name: 'opisAktivnosti',
                
            ),
          ),
          Expanded(
            child: FormBuilderTextField (
                decoration: const InputDecoration(labelText: "Datum zavrsenja ToDo4924a"), 
                name: 'datumZavrsenja',
                
                // initialValue: widget.todo4924?.datumZavrsenja ?? DateTime.now(),
                
            ),
          ),
          Expanded(
            child: FormBuilderTextField (
                decoration: const InputDecoration(labelText: "Status ToDo4924a"), 

                readOnly: true,
                name: 'stateMachine',
                
            ),
          ),
        

          // Expanded(
          //   child: FormBuilderTextField (
          //                   decoration: const InputDecoration(labelText: "Ime i prezime ToDo4924a"), 
          //       readOnly: true,

          //       name: 'korisnikId',
                
          //   ),
          // ),
          Expanded(
              child: 
                FormBuilderDropdown(
                      name: 'korisnikId',
                      decoration: const InputDecoration(labelText: 'Korisnik'),
                      items: 
                      List<DropdownMenuItem>.from(
                        _korisnikResult?.result.map(
                          (e) => DropdownMenuItem(
                            value: e.korisnikId.toString(),
                            child: Text("${e.ime} ${e.prezime} / ${e.korisnickoIme}"??"Nema imena"),
                            )).toList()??[]),

                      onChanged: (value) {
                        setState(() {
                          
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

          
          Column(
            children: [
              Row(
                children: [
                  ElevatedButton(onPressed: () async{
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => ToDo4924ListScreen(),
                      ),
                    );
                  }, child: const Text("Svi ToDo4924i")),
                  ElevatedButton(onPressed: () async{
                            setState(() { });
                          }, child: const Text("Osvježi podatke")),
                ],
              ),
              
              Row(
                children: [
                  ElevatedButton(onPressed: () async{
                          _formKey.currentState?.saveAndValidate(focusOnInvalid: false);
                          final formData = _formKey.currentState?.value;

                        // if (formData != null && formData['datumZavrsenja'] is String) {
                        //     formData['datumZavrsenja'] = DateFormat('yyyy-MM-dd').parse(formData['datumZavrsenja']);
                        //   }

                          try{
                            if(widget.todo4924==null) {
                              await _ToDo4924Provider.insert(formData);
                            } else {
                              await _ToDo4924Provider.update(widget.todo4924!.todo4924Id!,formData );
                            }
                        Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) => ToDo4924ListScreen(),
                  
                            ),
                                    );
                          } on Exception catch (err) {
                            showDialog(context: context, builder: (BuildContext context) => 
                                    AlertDialog(
                                      title: const Text("Greška"),
                                      content: Text(err.toString()),
                                      actions: [
                                        TextButton(onPressed: ()=>{
                                          Navigator.pop(context),
                                        }, child: const Text("OK"))
                                      ],
                                    ));
                          }
                        }, child: const Text("Spremi")),

                        ElevatedButton(
                          
                          onPressed: () async{
                          try {
                              await _ToDo4924Provider.realizuj(widget.todo4924!.todo4924Id!);

                              showDialog(context: context, builder: (BuildContext context) => 
                                  AlertDialog(
                                    title: const Text("Uspješna operacija!"),
                                    content: const Text("Aktivnost je realizirana."),
                                    actions: [
                                      TextButton(onPressed: ()=>{
                                        Navigator.of(context).push(
                                            MaterialPageRoute(builder: (context)=> ToDo4924ListScreen()
                                            )
                                        ) 
                                      }, child: const Text("OK"))
                                    ],
                                  ));
                          } catch (e) {
                            showDialog(context: context, builder: (BuildContext context) => 
                                  AlertDialog(
                                    title: const Text("Neuspješna operacija!"),
                                    content: const Text("Aktivnost nije realizovana. Datum je prošao."),
                                    actions: [
                                      TextButton(onPressed: ()=>{
                                        Navigator.of(context).push(
                                            MaterialPageRoute(builder: (context)=> ToDo4924ListScreen()
                                            )
                                        ) 
                                      }, child: const Text("OK"))
                                    ],
                                  ));
                          }
                        }, 
                        child: Text("Realizuj")),

                        ElevatedButton(
                          onPressed: () async{  
                          try {
                              await _ToDo4924Provider.istekni(widget.todo4924!.todo4924Id!);

                              showDialog(context: context, builder: (BuildContext context) => 
                                  AlertDialog(
                                    title: const Text("Uspješna operacija!"),
                                    content: const Text("Aktivnost istekla."),
                                    actions: [
                                      TextButton(onPressed: ()=>{
                                        Navigator.of(context).push(
                                            MaterialPageRoute(builder: (context)=> ToDo4924ListScreen()
                                            )
                                        ) 
                                      }, child: const Text("OK"))
                                    ],
                                  ));
                          } catch (e) {
                            showDialog(context: context, builder: (BuildContext context) => 
                                  AlertDialog(
                                    title: const Text("Neuspješna operacija!"),
                                    content: const Text("Aktivnost nije istekla."),
                                    actions: [
                                      TextButton(onPressed: ()=>{
                                        Navigator.of(context).push(
                                            MaterialPageRoute(builder: (context)=> ToDo4924ListScreen()
                                            )
                                        ) 
                                      }, child: const Text("OK"))
                                    ],
                                  ));
                          }
                        }, 
                        child: Text("Istekni")),
                        
                ],
              ),
            ],
          ),
            


          ],
          ),
          
        ),
        
      
    );
  }
}
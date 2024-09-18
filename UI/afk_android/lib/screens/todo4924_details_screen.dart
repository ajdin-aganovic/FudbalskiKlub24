
import 'package:afk_android/models/search_result.dart';
import 'package:afk_android/providers/korisnik_provider.dart';
import 'package:afk_android/providers/todo4924_provider.dart';
import 'package:afk_android/screens/todo4924_list_screen.dart';
import 'package:afk_android/utils/util.dart';
import 'package:afk_android/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';

import 'package:provider/provider.dart';

import '../models/korisnik.dart';
import '../models/todo4924.dart';

class ToDo4924EditableScreen extends StatefulWidget {
  Korisnik?korisnik;
  ToDo4924? todo4924;

  ToDo4924EditableScreen({this.todo4924,this.korisnik, super.key});

  @override
  State<ToDo4924EditableScreen> createState() => _ToDo4924EditableScreen();
}

class _ToDo4924EditableScreen extends State<ToDo4924EditableScreen> {

  final _formKey=GlobalKey<FormBuilderState>();

  Map<String,dynamic>_initialValue={};

  late ToDo4924Provider _todo4924Provider;
  SearchResult<ToDo4924>? _todo4924Result;

    late KorisnikProvider _korisnikProvider;
  SearchResult<Korisnik>? _korisnikResult;
  // bool isLoading=true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
  _initialValue= {
    'todo4924id':widget.todo4924?.todo4924id.toString()??"0",
    'nazivaktivnosti':widget.todo4924?.nazivaktivnosti??"",
    'opisaktivnosti': widget.todo4924?.opisaktivnosti??"", 
    'korisnikid': widget.todo4924?.korisnikid.toString()??"1", 
    'datumzavrsenja': widget.todo4924?.datumzavrsenja!.toIso8601String().substring(0,10)??"2024-09-18", 
    'statemachine': widget.todo4924?.statemachine??"nije postavljeno",
  };

    _todo4924Provider=context.read<ToDo4924Provider>(); 
    _korisnikProvider=context.read<KorisnikProvider>(); 

  initForm();
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();

  }

  
  String getKorisnickoIme(int id)
  {
    var pronadjeniKorisnik=_korisnikResult?.result.firstWhere((element) => element.korisnikId==id);
    // String? pronadjenoIme=_korisnikResult?.result.firstWhere((element) => element.korisnikId==id).korisnickoIme??"Nije pronađeno";
    String? pronadjenoIme="${pronadjeniKorisnik!.ime} ${pronadjeniKorisnik.prezime} - ${pronadjeniKorisnik.korisnickoIme}"??"Nije pronađeno";
    return pronadjenoIme;
  }

  List<Korisnik>sviKorisnici()
  {
    var lista = _korisnikResult?.result;
    return lista??[];
  }


  Future initForm()async{
    _todo4924Result=await _todo4924Provider.get();
    _korisnikResult=await _korisnikProvider.get();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: 'ToDo4924 ID: ${widget.todo4924?.todo4924id}' ?? "ToDo4924 detalji",
      child: buildForm()
     
      );
  }

  FormBuilder buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
        child: Padding(
          padding: const EdgeInsets.all(10.0),
          child: Column(children: [
            Expanded(
              child: FormBuilderTextField (
                readOnly: true,
                decoration: const InputDecoration(labelText: "Aktivnost ID"), 

                name: 'todo4924id',
                
                    ),
            ),
          Expanded(
            child: FormBuilderTextField (
                decoration: const InputDecoration(labelText: "Naziv"), 
                
                name: 'nazivaktivnosti',
            ),
          ),
          Expanded(
            child: FormBuilderTextField (
                            decoration: const InputDecoration(labelText: "Opis"), 

                name: 'opisaktivnosti',
                
            ),
          ),
          Expanded(
                      child:
                      FormBuilderDropdown(
                              name: 'korisnikid',
                              decoration: const InputDecoration(labelText: 'Korisnik'),
                              items: 
                              List<DropdownMenuItem>.from(
                                sviKorisnici().map((e) => 
                                 DropdownMenuItem(
                                  child: Text("${e.korisnickoIme}"??"Not set"), 
                                  value: e.korisnikId.toString()??"not set",
                                )
                                )
                              
                              ).toList(),
                              onChanged: (value) {
                                print(value);
                              },
                              validator: (value) {
                                if (value == null) {
                                  return 'Molimo Vas unesite korisnika';
                                }
                                return null;
                              },
                            ),
                    ),
          Expanded(
            child: FormBuilderTextField (
                            decoration: const InputDecoration(labelText: "Datum"), 

                name: 'datumzavrsenja',
                
            ),
          ),

          Expanded(
            child: FormBuilderTextField (
                            decoration: const InputDecoration(labelText: "Status"), 
                readOnly: true,
                name: 'statemachine',
                
            ),
          ),
          
          Row(
            children: [
              ElevatedButton(onPressed: () async{
                    _formKey.currentState?.saveAndValidate(focusOnInvalid: false);
                    print(_formKey.currentState?.value);
                    try{
                      if(widget.todo4924==null) {
                        await _todo4924Provider.insert(_formKey.currentState?.value);
                      } else {
                        await _todo4924Provider.update(widget.todo4924!.todo4924id!, _formKey.currentState?.value);
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
                  }, child: const Text("Snimi")),
                  
                  ElevatedButton(onPressed: () async{
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => ToDo4924ListScreen(),
                      ),
                    );
                  }, child: const Text("Sve aktivnosti")),

                  
                  ElevatedButton(onPressed: () async{
                    setState(() {
                      
                    });
                  }, child: const Text("Osvježi podatke")),
            ],
          ),

             Row(
               children: [
                 ElevatedButton(onPressed: () async{
                           showDialog(context: context, builder: (BuildContext context) => 
                        AlertDialog(
                          title: const Text("Realizacija!!!"),
                          content: Text("Da li ste sigurni da želite realizirati todo4924 ${widget.todo4924!.todo4924id}?"),
                          actions: [
                            
                            TextButton(onPressed: () async =>{
                              
                              await _todo4924Provider.realizuj(widget.todo4924!.todo4924id!),
                 
                              Navigator.of(context).push(
                                MaterialPageRoute(
                                  builder: (context) => ToDo4924ListScreen(),
                                ),
                              )
                          
                 
                            }, child: const Text("Da")),
                            TextButton(onPressed: ()=>{
                              Navigator.pop(context),
                            }, child: const Text("Ne")),
                  
                          ],
                        ));
                            
                          }, child: const Text("Realizuj")),
                 ElevatedButton(onPressed: () async{
                           showDialog(context: context, builder: (BuildContext context) => 
                        AlertDialog(
                          title: const Text("Istekni!!!"),
                          content: Text("Da li ste sigurni da želite isteknuti todo4924 ${widget.todo4924!.todo4924id}?"),
                          actions: [
                            
                            TextButton(onPressed: () async =>{
                              
                              await _todo4924Provider.istekni(widget.todo4924!.todo4924id!),
                 
                              Navigator.of(context).push(
                                MaterialPageRoute(
                                  builder: (context) => ToDo4924ListScreen(),
                                ),
                              )
                          
                 
                            }, child: const Text("Da")),
                            TextButton(onPressed: ()=>{
                              Navigator.pop(context),
                            }, child: const Text("Ne")),
                  
                          ],
                        ));
                            
                          }, child: const Text("Istekni")),
                 

               ],
             ),
          ],
          ),
        ),
      
    );
  }
}
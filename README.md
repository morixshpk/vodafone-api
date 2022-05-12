# vodafone-api

vodafone-api
Per te derguar sms, shtoni referencen Vodavone.API dhe ndiqni keto hapa

```
//Inicializo me kredecialet e llogarise qe ju ka ardhur nga vodafone

ApiClient.Init("apiUrl e dhene nga vodafone", "Sender Name or Number", "Username i dhene nga vodafone", "Password i dhene nga llogarise");

// inicializo instancen sms
var sms = new Sms
{
     Recipients = new string[] { "nr telefonit venodset ketu", "numri i dyte" },
     Message = "Mesazhi qe doni te dergoni vendset ketu",
};

// dergoje dhe shiko pergjigjen tek res
var res = ApiClient.Send(sms);
  
if (res.Equals("OK"))
{
      //Sms eshte derguar me sukses
}
else
{ 
    // nuk eshte derguar sms, variabli res permban informacione per gabimin qe ka ndodhur.
}
```
Happy coding!

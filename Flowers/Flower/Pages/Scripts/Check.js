
   function numeralsOnly(evt)
    {
        evt = (evt) ? evt : event;
        var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
        if (charCode > 31 && (charCode < 48 || charCode > 57))
        {
           return false;
        }
        return true;
   }
   function getfocus() {
       document.getElementById("Button1").focus();
   }
   function adress_Only(evt)
   {
       evt = (evt) ? evt : event;
        var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
        if (charCode ==45)
        {
            // alert("Wow!, So words much");
           return false;
        }
        return true;
   }
   debugger
   function symbolsOnly(evt) {
       evt = (evt) ? evt : event;
       var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
       if ((charCode==45||charCode==46 )||(charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || (charCode >= 1040 && charCode <= 1103))
       {
           return true;
       }
       return false;
   }

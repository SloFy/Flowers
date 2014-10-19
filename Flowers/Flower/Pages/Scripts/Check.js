
   function numeralsOnly(evt)
    {
        evt = (evt) ? evt : event;
        var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
        if (charCode > 31 && (charCode < 48 || charCode > 57))
        {
            // alert("Wow!, So words much");
           return false;
        }
        return true;
   }
   function getfocus() {
       document.getElementById("Button1").focus();
   }
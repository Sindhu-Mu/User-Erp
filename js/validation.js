
	function LengthCheck(val)
	{
		var vals;
		vals = val.value;
			if (vals.length < 8 )
			{
				return false;
			}
		return true;
	}	
	function phno(val)
	{
		var vals;
		vals = val.value;
			if (vals.length < 10 )
			{
				
				var r=isInteger(val)
				if(r==true)
				{
				return false;
				}
			}
		return true;
	}	
function SpaceCheck(val)
	{
	var char1,vals,flag;
	vals=val.value;
				
	if(vals != "") 
	{
	for (var i=0;i<vals.length;i++)
	{	 
		char1 = vals.substring(i,i+1); 
		if(char1==" ")
		{
			flag=1;
		}	
		else
		{
			flag=0;
			break;
		}	
	}		
	if (flag==1)
	{
		val.focus();
		return false;
	}
	else
	{
		return true;
	}
	}		
	else
	{	
	val.focus();	
	return false;
	}			
} 
		function Left(str, n)
		{
			if (n <= 0)    				return "";
			else if (n > String(str).length)	return str;
			else					return String(str).substring(0,n);
		}
		function Right(str, n)
		{
			if (n <= 0)				      	return "";
    		else if (n > String(str).length)		return str;
    		else 
			{
       			var iLen = String(str).length;
				return String(str).substring(iLen, iLen - n);
    		}
		}

		function bTrim(orgValue)
		{
			var tValue="";
			var i=0;
			while(orgValue.charAt(i)==' ')          
				i++;
			for( ;i<orgValue.length;i++) 
			{	
				if((orgValue.charAt(i-1)==' ') && (orgValue.charAt(i)==' ')) continue;
				else tValue=tValue.concat(orgValue.charAt(i));
			}   
			if(tValue.charAt(tValue.length-1)==' ')
				tValue=Left(tValue,tValue.length-1)
			return tValue;
		}
	function isEmail(mailValue)
	{
		tEmail="";
		tEmail=bTrim(mailValue);
		if (tEmail.indexOf("@")>0 && tEmail.indexOf(".")>0 && tEmail.length>=5 && tEmail.length-1 != tEmail.lastIndexOf(".") && tEmail.length != tEmail.lastIndexOf("@"))
		{
			tIndex1=tEmail.indexOf("@");
			tIndex2=tEmail.indexOf(".");
			/* This condition is to check, if first character of the email address
			   is either .(dot) or @ and if the character followed by .(dot) or @ is
			   @/.(dot) respectively then email address is not correct. Email will also
			   not correct if there are no or more than one @ sign in email and if 
			   there is a .(dot) or @ sign at the end of the email address and there 
			   is no character after it.
			*/
			if ((tEmail.charAt(0)!='@' || tEmail.charAt(0) !='.') && tEmail.charAt(tIndex1+1)!= '.'  && tEmail.charAt(tIndex1+1)!= ' ' && tEmail.indexOf("@") == tEmail.lastIndexOf("@") && tEmail.lastIndexOf("@") < tEmail.lastIndexOf("."))
			{
				var flag=0;
				for (i=0;i<tEmail.length;i++){
					/* This condition is to check, if there is any space in email or 
					   any @ sign followed by .(dot) then email address is not correct
					*/
					if (tEmail.charAt(i)== ' ' ||( tEmail.charAt(i)== '.' && tEmail.charAt(i+1)=='@'))
					{
						flag=1;
						break;
					}
				}
				if (flag==1)
					return false;
				else
					return true;
			}
			else 
				return false;
		}
		else
			return false;
	}
	
function SpCharCheck(val)
{
	var char1,vals,fla;
	vals=val.value;
	for (var i=0;i<vals.length;i++)
		{	
		char1 = vals.substring(i,i+1); 
		if ((char1=='>')||(char1=='"')||(char1=="'")||(char1=='<')||(char1=='@')||(char1=='!')||(char1=='~')||(char1=='#')||(char1=='$')||(char1=='%')||(char1=='&')||(char1=='*'))
		{
			fla=1;
			break;	
		}	
		else
		{
			fla=0;
		}	
		}		
	if (fla==1)
	{
		val.focus();
		return false;
	}
	else
	{
		return true;
	}
} 
   
	function OnlyDigit()
	{	var eAny_Event = window.event;
		var iKey = eAny_Event.keyCode;
		if ( (iKey <48 || iKey >57) && iKey!=13)
			window.event.returnValue=false;      	
	}
	function OnlyDigitWithDecimal()
	{	var eAny_Event = window.event;
		var iKey = eAny_Event.keyCode;
		if ( (iKey <48 || iKey >57) && iKey!=13 && iKey!=46)
			window.event.returnValue=false;
			      	
	}
	function OnlyDigitWithSingleDecimal(ctrl)
    {
    var aData = document.getElementById(ctrl).value;
    var eAny_Event = window.event;
    var iKey = eAny_Event.keyCode;
    if(aData.indexOf(".")>0 && iKey==46)
        window.event.returnValue=false;
    if ( (iKey <48 || iKey >57) && iKey!=13 && iKey!=46)
			    window.event.returnValue=false;

    }
	function OnlyAlpha()
	{	var eAny_Event = window.event;
		var iKey = eAny_Event.keyCode;
		if (! ((iKey >=65 && iKey <=90) || (iKey >=97 && iKey <=122) || iKey==13) )
			window.event.returnValue=false;      	
	} 
	function OnlySpaceAlpha()
	{	var eAny_Event = window.event;
		var iKey = eAny_Event.keyCode;
		if (! ((iKey >=65 && iKey <=90) || (iKey >=97 && iKey <=122) || iKey==32 || iKey==13) )
			window.event.returnValue=false;      	
	}
	
	function isValidName(strName)
	{	
		var ch = strName.substring(0, 1);
		if ((ch < "a" || "z" < ch)&&(ch < "A" || "Z" < ch)) 
			return false;
		for (var i = 1; i < strName.length; i++) 
		{
			var ch = strName.substring(i, i + 1);
			if ( ((ch < "a" || "z" < ch) && (ch < "A" || "Z" < ch)) &&(ch != ' ') && (ch != '.') ) 
				return false;
		}	  
		return true;
	}
function printPartOfPage(elementId)
        {
            var printContent = document.getElementById(elementId);
            var windowUrl = '../common/printDoc.aspx';
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            
            var printWindow = window.open(windowUrl, windowName, 'left=50000,top=50000,width=0,height=0');
           printWindow.document.write(printContent.innerHTML);
           printWindow.document.close();
           printWindow.focus();
            printWindow.print();
           printWindow.close();
}
function MobileNumber()
{
    var y = document.getElementById(ctrl).value;

    if (isNaN(y) || y.indexOf(" ") != -1) {
        alert("Enter numeric value")
        return false;
    }
    if (y.length > 10) {
        alert("enter 10 characters");
        return false;
    }
}

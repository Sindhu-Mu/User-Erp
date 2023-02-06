
        function Focus(objname, waterMarkText) {
            obj = document.getElementById(objname);
            if (obj.value == waterMarkText) {
                obj.value = "";
                obj.className = "";
                if (obj.value == waterMarkText || obj.value == "" || obj.value == null) {
                    obj.style.color = "black";
                }
            }
        }
        function Blur(objname, waterMarkText) {
            obj = document.getElementById(objname);
            if (obj.value == "") {
                obj.value = waterMarkText;
                    obj.className = "waterMarkedTextBox";
            }
            else {
                obj.className = "";
            }

            if (obj.value == waterMarkText || obj.value == "" || obj.value == null) {
                obj.style.color = "gray";
            }
        }



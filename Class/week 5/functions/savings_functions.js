/*
	Scott Nevin
	Created: 09/28/15
	Purpose: Javascript file to hold functions
*/

//First savings function implementing a for loop
function save1(pv,int,n){
	for(var year=1;year<=n;year++){
		pv*=(1+int);
	}
	return pv;
}

//Savings function that implements the power function
function save2(pv,int,n){
	return pv*Math.pow((1+int),n);
}

//Savings function that implements the logarithmic function
function save3(pv,int,n){
	return pv*Math.exp(n*Math.log(1+int));
}

//Savings function that implements recusrsion of itself
function save4(pv,int,n){
	if(n<=0) return pv;
	else return save4(pv,int,n-1)*(1+int);
}

//Savings function that implements arrays
function save5(pv,int,n){
	//Declare Array
	fv=[];
	//calculate all values in array
	fv[0]=pv;
	for(var year=1;year<=n;year++){
		fv[year]=fv[year-1]*(1+int);
	}
	return fv;
}

//Function for displaying array in save 5
function display(fv){
	document.write('<table width="200" border="1">');
	document.write("<tr><th>Years</th><th>Savings</th></tr>");
	for(var year=0;year<fv.length;year++){
		document.write("<tr>");
		document.write("<td>"+year+"</td>");
		document.write("<td>$"+fv[year].toFixed(2)+"</td>");
		document.write("</tr>");
	}
	document.write("</table>");
}
$(document).ready(function(){
var catId;



function loadDropDown()
{
	$.ajax({
		url:"http://localhost:51072//api/categories",
		method:"GET",
		
		headers:{
			"Authorization":"Basic "+btoa("admin:123")
		},
		complete:function(xmlHttp,status){
			if(xmlHttp.status==200)
			{
				var str='';
				var data=xmlHttp.responseJSON;
				for (var i = 0; i < data.length; i++) {
					
					str+="<option value="+data[i].categoryId+">"+data[i].categoryName+"</option>";
				}

				$("#selectCategory").html(str);
			}
			else
			{
				$("#msg").html(xmlHttp.status+":"+xmlHttp.statusText);
			}
		}
	});
}



	$("#loadbtn").click(function(){

		$.ajax({
		url:"http://localhost:51072//api/categories",
		method:"GET",

		headers:{
			"Authorization":"Basic "+btoa("admin:123")
		},
		complete:function(xmlHttp,status){
			if(xmlHttp.status==200)
			{
				var str='';
				var data=xmlHttp.responseJSON;
				for (var i = 0; i < data.length; i++) {
					
					str+="<tr><td>"+data[i].categoryId+"</td><td>"+data[i].categoryName+"</td></tr>";
				}

				$("#tblCategoryList tbody").html(str);
			}
			else
			{
				$("#msg").html(xmlHttp.status+":"+xmlHttp.statusText);
			}
		}
	});
	});


	$("#addCategory").click(function(){

		$.ajax({
		url:"http://localhost:51072//api/categories",
		method:"POST",
		headers:"Content-Type:application/json",
		data:{
			"categoryName":$("#categoryName").val()
		},
		complete:function(xmlHttp,status){
			if(xmlHttp.status==201)
			{
				$("#msg").html(xmlHttp.status+":"+xmlHttp.statusText);
			}
			else
			{
				$("#msg").html(xmlHttp.status+":"+xmlHttp.statusText);
			}
		}
	});
	});


	$("#selectCategory").change(function(){
		$("#updateCategoryName").val($("#selectCategory option:selected").text());
		catId=$("#selectCategory option:selected").val();
	});



	$("#updateCategory").click(function(){

		$.ajax({
		url:"http://localhost:51072//api/categories/"+catId,
		method:"PUT",
		headers:"Content-Type:application/json",
		data:{
			"categoryName":$("#updateCategoryName").val()
		},
		complete:function(xmlHttp,status){
			if(xmlHttp.status==200)
			{
				$("#msg").html(xmlHttp.status+":"+xmlHttp.statusText);
				loadDropDown();
			}
			else
			{
				$("#msg").html(xmlHttp.status+":"+xmlHttp.statusText);
			}
		}
	});
	});

	loadDropDown();

});


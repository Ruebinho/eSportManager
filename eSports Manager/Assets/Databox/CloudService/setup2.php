<?php

function Install()
{
	include ('config.php');
		
	$error_msg = "";

	$db_error=false;
	$conn = new mysqli($dbhost, $dbuser, $dbpass, $dbname);

	// try to connect to the DB, if not display error
	if ($conn -> connect_error)
	{
	  $db_error=true;
	  $error_msg="Could not connect to MySQL database. Please check config.php. ".mysqli_error();
	}
	 
	if (!$db_error)
	{
		$db = mysqli_connect($dbhost, $dbuser,$dbpass);
		
		$q="CREATE TABLE `{$dbtable}` (
		`id` VARCHAR(255) NOT NULL,
		`version` VARCHAR(255) NOT NULL,
		`data` LONGTEXT NOT NULL, PRIMARY KEY (`id`)) ENGINE = InnoDB;"; 
		
		mysqli_select_db ($db, $dbname);
		if (!mysqli_query($db, $q))
		{
			$error_msg = "mysql querry error: ".mysqli_error($db);
		}
	}
	
	return $error_msg;
}

?>



<html>
<head>
<link href='https://fonts.googleapis.com/css?family=Barlow Condensed' rel='stylesheet'>
</head>
<style>
.tableshadow 
{ 
	box-shadow: 5px 10px 18px #000000; 
}
body {
    font-family: 'Barlow Condensed';font-size: 22px;
	background-color: #707070;
	background-image: linear-gradient(#707070, #2b2b2b); 
}
</style>

<table style="width: 100%; height: 100%; margin-left: auto; margin-right: auto;" border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td>
<table style="width: 520px; height: 450px; margin-left: auto; margin-right: auto;" border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td style="width: 250px;">&nbsp;
<table class="tableshadow" style="width: 250px; height: 450px; background-color: #2b2b2b; margin-left: auto; margin-right: auto;" border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td style="text-align: center;">
<h2><span style="color: #999999;">Welcome to the DataBox cloud installation.</span></h2>
</td>
</tr>
<tr>
<td style="text-align: center;">
<h4><span style="color: #999999;">Step 1</span></h4>
</td>
</tr>
<tr>
<td style="text-align: center;"><form><span style="color: #999999;">Database Host:</span><br /> <input name="firstname" type="text" /><br /> <span style="color: #999999;">Database Name:</span><br /> <input name="lastname" type="text" /><br /> <span style="color: #999999;">Database User:</span><br /> <input name="firstname" type="text" /><br /> <span style="color: #999999;">Database Password:</span><br /> <input name="firstname" type="text" /><br /> <span style="color: #999999;">Database Table:</span><br /> <input name="firstname" type="text" /></form></td>
</tr>
</tbody>
</table>
</td>
<td style="width: 20px;">&nbsp;</td>
<td style="width: 250px;">&nbsp;
<table class="tableshadow" style="width: 250px; height: 450px; margin-left: auto; margin-right: auto; background-color: #2b2b2b;" border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td><img style="display: block; margin-left: auto; margin-right: auto;" src="logo.png" alt="" width="250" height="180" /></td>
</tr>
<tr>
<td>
<h4 style="text-align: center;"><span style="color: #999999;">Step 2</span></h4>
</td>
</tr>
<tr>
<td>
<div id="form" style="text-align: center;"><form action="setup.php" method="post"><input style="height: 50px; width: 200px;" name="submit" type="submit" value="INSTALL" /> <!-- assign a name for the button --></form></div>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>


</html>
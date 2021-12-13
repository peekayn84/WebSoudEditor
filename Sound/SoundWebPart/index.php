<form action="index.php" method="post">
<input type="range" min="0" max="100" name="volume" step="1" value=<?php echo $_POST['volume']; ?>> 
 <p><input type="submit" /></p>
</form>

<?php if ($_POST['volume']!=""){
	file_get_contents("http://93.76.191.35:8888/connection?value=".$_POST['volume']);
	//echo "http://93.76.191.35:8888/connection?value=".$_POST['volume'];
} 
//file_get_contents("http://93.76.191.35:8888/connection?value=99");
?>
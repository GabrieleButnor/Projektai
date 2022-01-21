<?php
echo "XXX";
$numeris = $_POST["numeris"];
$pavadinimas = $_POST["pavadinimas"];
$autorius = $_POST["autorius"];
$isleidimo_data = $_POST["isleidimo_data"];
$leidejas = $_POST["leidejas"];
$zanras = $_POST["zanras"];
$busena = $_POST["busena"];
$puslapiu_sk = $_POST["puslapiu_sk"];
$komentaras = $_POST["komentaras"];

$servername = "localhost";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

$conn = new mysqli($servername, $username, $password, $dbname);
mysqli_set_charset($conn,"utf8");

if ($conn->connect_error){die("Connection failed: " . $conn->connect_error);} 

$sql="UPDATE book SET pavadinimas = '$pavadinimas', autorius = '$autorius', isleidimo_data = '$isleidimo_data', leidejas = '$leidejas', ".
	"zanras = '$zanras', busena = '$busena', puslapiu_sk = '$puslapiu_sk', komentaras = '$komentaras' WHERE numeris = '$numeris'";

$conn->query($sql);
echo "XXX";
$conn->close();
?>
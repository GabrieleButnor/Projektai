<?php
$ID = $_POST["ID"];

$servername = "localhost";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

$conn = new mysqli($servername, $username, $password, $dbname);
mysqli_set_charset($conn,"utf8");

if ($conn->connect_error){die("Connection failed: " . $conn->connect_error);} 


$sql = "SELECT busena FROM book WHERE numeris = '$ID'";

echo $sql;

$result = $conn->query($sql); $result = $result->fetch_assoc(); $result = $result["busena"];

$sql = "INSERT INTO del_stats SET count=1, state='$result' ON DUPLICATE KEY UPDATE count=count+1";

echo $sql;
$conn->query($sql);

$sql = "DELETE FROM book WHERE numeris = ".$ID;

$conn->query($sql);
$conn->close();
?>
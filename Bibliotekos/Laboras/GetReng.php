<?php
class Renginys
{
    public $id;
	public $Pavadinimas;



    public function __construct(array $data) 
    {
        $this->id = $data['id'];
		$this->Pavadinimas = $data['Pavadinimas'];
		
    }
}
$servername = "localhost";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$sql = "SELECT `ID`,`Pavadinimas` FROM `Renginiai`";
#$sql = "SELECT `guid` FROM user WHERE `username`='".$usernamePassed ."' AND `password`='".$passwordPassed."'"; 
#echo $sql;
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        #echo "id: " . $row["ID"]. " - Name: " . $row["Name"]. " " . $row["Type"]. "<br>";
    $est = new Renginys(array('id' => $row["ID"], 'Pavadinimas' => $row["Pavadinimas"]));
    $establishments[] = $est;
    }
} else {
    echo "0 results";
}
$conn->close();
echo json_encode($establishments);
$conn->close();
?>
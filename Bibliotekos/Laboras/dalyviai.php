

<?php


class Renginys
{
    public $id;
    public $RenginioID;
	public $Vardas;
	public $Pavarde;
	public $ElPastas;
	public $TelNr;
	


    public function __construct(array $data) 
    {
        $this->id = $data['id'];
        $this->RenginioID = $data['RenginioID'];
        $this->Vardas = $data['Vardas'];
		$this->Pavarde = $data['Pavarde'];
		$this->ElPastas = $data['ElPastas'];
		$this->TelNr = $data['TelNr'];
   		
		
    }
}
#$est = new Establishment(array('id' => 1, 'name' => 'Amir'));

$establishments = array();

$rengID=$_POST["rengID"];

$servername = "carpartshop.net";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
mysqli_set_charset($conn,"utf8");
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 


$sql = "SELECT
   RenginiuDalyviai.`ID`,RenginiuDalyviai.`RenginioID`,RenginiuDalyviai.`Vardas`,RenginiuDalyviai.`Pavarde`,RenginiuDalyviai.`ElPastas`,RenginiuDalyviai.`TelNr`
  
FROM RenginiuDalyviai
  INNER JOIN Renginiai
    ON RenginiuDalyviai.RenginioID = Renginiai.ID
    WHERE Renginiai.ID=$rengID";


$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        #echo "id: " . $row["ID"]. " - Name: " . $row["Name"]. " " . $row["Type"]. "<br>";
    $est = new Renginys(array('id' => $row["ID"], 'RenginioID' => $row["RenginioID"] , 'Vardas' => $row["Vardas"] ,'Pavarde' => $row["Pavarde"], 'ElPastas' => $row["ElPastas"],
                                   'TelNr' => $row["TelNr"]));
    $establishments[] = $est;
    }
} else {
    echo "0 results";
}
$conn->close();
echo json_encode($establishments);
#$result = $conn->query($sql);
#$row = $result->fetch_assoc();
#$toScreen = $row["Name"];

#echo $toScreen;
#$conn->close();
?>
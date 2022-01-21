


<?php


class Renginys
{
    public $id;
    public $Tipas;
	public $SukurimoData;
	public $RenginioData;
	public $Vieta;
	public $Pavadinimas;
	public $Laikas;
	public $Aprasas;
	public $DalyviuSk;


    public function __construct(array $data) 
    {
        $this->id = $data['id'];
        $this->Tipas = $data['Tipas'];
        $this->SukurimoData = $data['SukurimoData'];
		$this->RenginioData = $data['RenginioData'];
		$this->Vieta = $data['Vieta'];
		$this->Pavadinimas = $data['Pavadinimas'];
   		$this->Laikas = $data['Laikas'];
    	$this->Aprasas = $data['Aprasas'];
    	$this->DalyviuSk = $data['DalyviuSk'];
		
    }
}
#$est = new Establishment(array('id' => 1, 'name' => 'Amir'));

$establishments = array();


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
  Renginiai.ID,
  Renginiai.Tipas,
  Renginiai.SukurimoData,
  Renginiai.RenginioData,
  Renginiai.Vieta,
  Renginiai.Pavadinimas,
  Renginiai.Laikas,
  Renginiai.Aprasas,
  CASE
    WHEN COUNT(RenginiuDalyviai.RenginioID) = NULL THEN 0
    ELSE COUNT(RenginiuDalyviai.RenginioID) END AS DalyviuSk
FROM RenginiuDalyviai
  RIGHT JOIN Renginiai
    ON RenginiuDalyviai.RenginioID = Renginiai.ID
GROUP BY Renginiai.ID,
         Renginiai.Tipas,
         Renginiai.SukurimoData,
         Renginiai.RenginioData,
         Renginiai.Vieta,
         Renginiai.Pavadinimas,
         Renginiai.Laikas,
         Renginiai.Aprasas";


$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        #echo "id: " . $row["ID"]. " - Name: " . $row["Name"]. " " . $row["Type"]. "<br>";
    $est = new Renginys(array('id' => $row["ID"], 'Tipas' => $row["Tipas"] , 'SukurimoData' => $row["SukurimoData"] ,'RenginioData' => $row["RenginioData"], 'Vieta' => $row["Vieta"],
                                   'Pavadinimas' => $row["Pavadinimas"], 'Laikas' => $row["Laikas"], 'Aprasas' => $row["Aprasas"], 'DalyviuSk' => $row["DalyviuSk"]));
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
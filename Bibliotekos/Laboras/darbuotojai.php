


<?php


class Naudotojas
{
    public $id;
    public $vardas;
	public $pavarde;
	public $gd;
	public $pastas;
	public $telnr;
	public $adr;
	public $pareigos;
	


    public function __construct(array $data) 
    {
        $this->id = $data['id'];
        $this->vardas = $data['Vardas'];
        $this->pavarde = $data['Pavardė'];
		$this->gd = $data['gd'];
		$this->pastas = $data['pastas'];
		$this->telnr = $data['telnr'];
   		$this->adr = $data['adr'];
    	$this->pareigos = $data['pareigos'];
		
    }
}
#$est = new Establishment(array('id' => 1, 'name' => 'Amir'));

$establishments = array();


$servername = "localhost";
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


$sql = " SELECT
	logins.ID,
  logins.Vardas,
  logins.Pavardė,
  logins.`Gimimo Data` AS GD,
  logins.`El. Paštas`,
  logins.Telefonas,
  logins.Adresas,
  Pareigos.pareigos AS pareigos
FROM logins
  INNER JOIN Pareigos
    ON logins.type = Pareigos.ID WHERE 1";


$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        #echo "id: " . $row["ID"]. " - Name: " . $row["Name"]. " " . $row["Type"]. "<br>";
    $est = new Naudotojas(array('id' => $row["ID"], 'Vardas' => $row["Vardas"] , 'Pavardė' => $row["Pavardė"] ,'gd' => $row["GD"], 'pastas' => $row["El. Paštas"],
                                   'telnr' => $row["Telefonas"], 'adr' => $row["Adresas"], 'pareigos' => $row["pareigos"]));
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
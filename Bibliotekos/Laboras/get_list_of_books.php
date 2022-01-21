<?php
class Book{
	public $numeris;
	public $pavadinimas;
	public $autorius;
	public $isleidimo_data;
	public $leidejas;
	public $zanras;
	public $busena;
	public $puslapiu_sk;
	public $komentaras;
	
    public function __construct(array $data) {
        $this->numeris = $data['numeris'];
        $this->pavadinimas = $data['pavadinimas'];
        $this->autorius = $data['autorius'];
		$this->isleidimo_data = $data['isleidimo_data'];
		$this->leidejas = $data['leidejas'];
		$this->zanras = $data['zanras'];
   		$this->busena = $data['busena'];
		$this->puslapiu_sk = $data['puslapiu_sk'];
		$this->komentaras = $data['komentaras'];
    }
}

$zanras = $_POST["genre"];

$establishments = array();

$servername = "carpartshop.net";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

$conn = new mysqli($servername, $username, $password, $dbname);

mysqli_set_charset($conn,"utf8");
if ($conn->connect_error){die("Connection failed: " . $conn->connect_error);} 

$sql = "SELECT numeris, pavadinimas, autorius, isleidimo_data, leidejas, zanras, busena, puslapiu_sk, komentaras FROM book";
if($zanras != '0'){
	$sql = $sql." WHERE zanras = ".$zanras;
}

$result = $conn->query($sql);

if ($result->num_rows > 0){
    while($row = $result->fetch_assoc()){
		$est = new Book(array('numeris' => $row["numeris"], 'pavadinimas' => $row["pavadinimas"], 'autorius' => $row["autorius"],
			'isleidimo_data' => $row["isleidimo_data"], 'leidejas' => $row["leidejas"], 'zanras' => $row["zanras"], 'busena' => $row["busena"],
			'puslapiu_sk' => $row["puslapiu_sk"], 'komentaras' => $row["komentaras"]));
		$establishments[] = $est;
    }
}
else{echo "0 results";}
$conn->close();
echo json_encode($establishments);
?>
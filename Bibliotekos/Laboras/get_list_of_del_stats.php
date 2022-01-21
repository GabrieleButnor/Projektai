<?php
class Book{
	public $state;
	public $count;
	
    public function __construct(array $data) {
        $this->state = $data['state'];
        $this->count = $data['count'];
    }
}

$establishments = array();

$servername = "localhost";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

$conn = new mysqli($servername, $username, $password, $dbname);

mysqli_set_charset($conn,"utf8");
if ($conn->connect_error){die("Connection failed: " . $conn->connect_error);} 

$sql = "SELECT state, count FROM del_stats";

$result = $conn->query($sql);

if ($result->num_rows > 0){
    while($row = $result->fetch_assoc()){
		$est = new Book(array('state' => $row["state"], 'count' => $row["count"]));
		$establishments[] = $est;
    }
}
else{echo "0 results";}
$conn->close();
echo json_encode($establishments);
?>
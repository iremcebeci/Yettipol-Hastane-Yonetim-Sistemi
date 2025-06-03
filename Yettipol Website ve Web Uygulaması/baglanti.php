<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "yettipol";

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$conn->set_charset("utf8");

$sql = "SET NAMES 'utf8'"; 
$conn->query($sql);
?>

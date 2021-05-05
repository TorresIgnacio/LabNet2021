<?php
    $data = json_decode($_POST['data'], true);
    $nombre = $data['name'];
    echo "Welcome $nombre $apellido!";
?>
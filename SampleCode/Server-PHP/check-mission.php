<?php

    // userId, appId, missionKey, missionValue, header는 게임에 맞게 값을 넣으면 됩니다.

    $toast_url = 'https://api-campaign-analytics.cloud.toast.com/campaign/v1/server/check-mission';

    $post_data = array();
    $post_data['userId'] = "USERID";
    $post_data['appId'] = "APPID" ;
    $post_data['missionKey'] = "KEY" ;
    $post_data['missionValue'] = VAL;
    $post_data['header'] = array('transactionId' =>time());     // time은 게임에서 임의의 값을 사용하면 됩니다. Sample로 Time을 사용했습니다.

    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL, $toast_url);
    curl_setopt($ch, CURLOPT_POST, true);
    curl_setopt($ch, CURLOPT_POSTFIELDS, $post_data);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, FALSE); 
    curl_setopt($ch, CURLOPT_HTTPHEADER, array(                                                                          
        ‘Content-Type: application/json’
        )
    );     
    $result = curl_exec($ch);

?>
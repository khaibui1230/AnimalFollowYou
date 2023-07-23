using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public Camera mainCamera;
    public GameObject shootPrefab;
    public Transform shootPoint;
    // gia tri de co the ban ra tu xa
    public float shootingDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // ham duy chuyen nguoi choi
        movePlayer();
        // ham can kich thuoc nguoi choi
        scanScreen();
        // ham giup nguoi choi ban ra do an khi an Space
        shootting();
        
    }

    void shootting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 shootingDirection = transform.forward;
            Vector3 spawnPosition = shootPoint.position + shootingDirection * shootingDistance;
            Instantiate(shootPrefab,spawnPosition,shootPrefab.transform.rotation);
        }
    }

    void scanScreen()
    {
        // Lấy kích thước của màn hình
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Chuyển vị trí người chơi từ tọa độ màn hình thành tọa độ thế giới
        Vector3 playerScreenPos = mainCamera.WorldToScreenPoint(transform.position);

        // Giới hạn tọa độ người chơi trong giới hạn màn hình
        float clampedX = Mathf.Clamp(playerScreenPos.x, 0f, screenWidth);
        float clampedY = Mathf.Clamp(playerScreenPos.y, 0f, screenHeight);

        // Chuyển tọa độ người chơi từ tọa độ màn hình trở lại tọa độ thế giới
        Vector3 clampedPlayerPos = mainCamera.ScreenToWorldPoint(new Vector3(clampedX, clampedY, playerScreenPos.z));

        // Đặt lại vị trí người chơi trong giới hạn màn hình
        transform.position = clampedPlayerPos;
    }

    void movePlayer()
    {
        // di chuyen theo chieu ngang
        float horizontalInput = Input.GetAxis("Horizontal");
        // ap luc vao doi tuon
        transform.Translate(horizontalInput * Time.deltaTime * speed * Vector3.right);

        // di chuyen nguoi choi theo chieu doc
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(verticalInput* Time.deltaTime * speed *Vector3.forward);
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Transform _playerTransform;
   private Rigidbody _playerRb;
  
   [Header("Movement")]
   public float moveSpeed;
   public float rotationSpeed;
   [Header("Dash")]
   public float dashDistance;
   public float lastDashTime;
   public float dashCooldown;
   
   private float _horizontalInput;
   private float _verticalInput;
   
   
   private void Start()
   {
      _playerTransform = GetComponent<Transform>();
      _playerRb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      GetInput();
      Move();
      Rotate();
      if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastDashTime + dashCooldown) // Space tuşuna basılması ve cooldown süresinin dolmuş olması kontrolü
      {
         Dash();
      }
   }

   
   
   private void Move()
   {
      _playerTransform.position += new Vector3(_horizontalInput, 0f, _verticalInput) * (moveSpeed * Time.deltaTime);
   }

   private void Rotate()
   {
      Vector3 direction = new Vector3(_horizontalInput, 0f, _verticalInput);
      if (direction != Vector3.zero)  // Sıfır vektörü değilse, yani bir girdi varsa
      {
         Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
         _playerTransform.rotation = Quaternion.RotateTowards(_playerTransform.rotation, toRotation, (rotationSpeed*100) * Time.deltaTime);
      }
   }

   private void Dash()
   {
      Vector3 dashDirection = _playerTransform.forward * dashDistance; // Karakterin baktığı yönde ileri doğru dash mesafesi kadar hareket
      _playerTransform.position += dashDirection;
      lastDashTime = Time.time; // Son dash zamanını güncelle
      
   }

   private void GetInput()
   {
      _horizontalInput = Input.GetAxisRaw("Horizontal");
      _verticalInput = Input.GetAxisRaw("Vertical");
   }
}

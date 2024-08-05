/* USER CODE BEGIN Header */
/**
 ******************************************************************************
 * @file           : main.c
 * @brief          : Main program body
 ******************************************************************************
 * @attention
 *
 * Copyright (c) 2024 STMicroelectronics.
 * All rights reserved.
 *
 * This software is licensed under terms that can be found in the LICENSE file
 * in the root directory of this software component.
 * If no LICENSE file comes with this software, it is provided AS-IS.
 *
 ******************************************************************************
 */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */

/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */

/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
UART_HandleTypeDef huart1;

/* USER CODE BEGIN PV */
uint8_t rData[1]; // Alınan veriyi depolamak için buffer dizisi
uint8_t packetCompleted = 0; // Paketin tamamlandığını belli etmek için flag
uint8_t check = 0; // paketi ayrıştırmak için durum değişkeni
uint8_t dataPacket[7]; // paketin tamamını saklamak için buffer dizisi
uint8_t dataStepArray[6]; // data paketi içindeki adım sayısı içeren kısım
uint32_t stepValue = 0; // step değerini int olarak saklamak için değişken
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_USART1_UART_Init(void);
/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{

  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init(); // HAL kütüphanesini başlat

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init(); // initialize GPIO
  MX_USART1_UART_Init(); // initialize uart1
  /* USER CODE BEGIN 2 */

  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
	while (1) {

    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
		HAL_GPIO_WritePin(motor_ena_pozitif_GPIO_Port, motor_ena_pozitif_Pin, GPIO_PIN_SET); // motoru enable et
		for (uint32_t i = 0; i < 6400; i++) {
			HAL_GPIO_WritePin(motor_pulse_GPIO_Port, motor_pulse_Pin,
					GPIO_PIN_SET); // motor pulse pinini high yap
			HAL_Delay(1); // 1 ms bekle
			HAL_GPIO_WritePin(motor_pulse_GPIO_Port, motor_pulse_Pin,
					GPIO_PIN_RESET); // motor pulse pinini low yap
			HAL_Delay(1); // 1 ms bekle
		}

		HAL_Delay(2000); // 2 sn. bekle
	}
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};
  RCC_PeriphCLKInitTypeDef PeriphClkInit = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSICalibrationValue = RCC_HSICALIBRATION_DEFAULT;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSI;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL12;
  RCC_OscInitStruct.PLL.PREDIV = RCC_PREDIV_DIV1;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_1) != HAL_OK)
  {
    Error_Handler();
  }
  PeriphClkInit.PeriphClockSelection = RCC_PERIPHCLK_USART1;
  PeriphClkInit.Usart1ClockSelection = RCC_USART1CLKSOURCE_PCLK1;
  if (HAL_RCCEx_PeriphCLKConfig(&PeriphClkInit) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief USART1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART1_UART_Init(void)
{

  /* USER CODE BEGIN USART1_Init 0 */

  /* USER CODE END USART1_Init 0 */

  /* USER CODE BEGIN USART1_Init 1 */

  /* USER CODE END USART1_Init 1 */
  huart1.Instance = USART1;
  huart1.Init.BaudRate = 9600;
  huart1.Init.WordLength = UART_WORDLENGTH_8B;
  huart1.Init.StopBits = UART_STOPBITS_1;
  huart1.Init.Parity = UART_PARITY_NONE;
  huart1.Init.Mode = UART_MODE_TX_RX;
  huart1.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart1.Init.OverSampling = UART_OVERSAMPLING_16;
  huart1.Init.OneBitSampling = UART_ONE_BIT_SAMPLE_DISABLE;
  huart1.AdvancedInit.AdvFeatureInit = UART_ADVFEATURE_NO_INIT;
  if (HAL_UART_Init(&huart1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART1_Init 2 */
  HAL_UART_Receive_IT(&huart1, &rData[0], 1); // UART1 için kesmeli veri alma işlemini etkinleştir. Bu, UART üzerinden veri alındığında bir kesme meydana geleceği anlamına gelir ve veri alındığında 'rData' tamponuna yazılacaktır.
  /* USER CODE END USART1_Init 2 */

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};
/* USER CODE BEGIN MX_GPIO_Init_1 */
/* USER CODE END MX_GPIO_Init_1 */

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOF_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOB, motor_ena_negatif_Pin|motor_dir_Pin|motor_pulse_Pin, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(motor_ena_pozitif_GPIO_Port, motor_ena_pozitif_Pin, GPIO_PIN_SET);

  /*Configure GPIO pins : motor_ena_negatif_Pin motor_ena_pozitif_Pin motor_dir_Pin motor_pulse_Pin */
  GPIO_InitStruct.Pin = motor_ena_negatif_Pin|motor_ena_pozitif_Pin|motor_dir_Pin|motor_pulse_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

/* USER CODE BEGIN MX_GPIO_Init_2 */
/* USER CODE END MX_GPIO_Init_2 */
}

/* USER CODE BEGIN 4 */
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
	if(HAL_UART_Receive_IT(huart1, &rData[0], 1) != HAL_OK){
		Error_Handler();
	}

	if(check == 0){
		dataPacket[check] = rData[0];
		if(dataPacket[check] == "M"){
			check = 1;
		}
		else{
			check = 0;
		}
	}else if(check == 1 && dataPacket[0] == "M"){
		dataPacket[check] = rData[0];
		if(dataPacket[check] == "1" || dataPacket[check] == "0"){
			check = 2;
		}else{
			check = 0;
		}
	}else if(check == 2 && dataPacket[0] == "M"){
		dataPacket[check] = rData[0];
		if(dataPacket[check] > 0x2F && dataPacket[check] < 0x3A){
			check = 3;
		}else{
			check = 0;
		}
	}else if(check == 3 && dataPacket[0] == "M"){
		dataPacket[check] = rData[0];
		if(dataPacket[check] > 0x2F && dataPacket[check] < 0x3A){
			check = 4;
		}else{
			check = 0;
		}
	}else if(check == 4 && dataPacket[0] == "M"){
		dataPacket[check] = rData[0];
		if(dataPacket[check] > 0x2F && dataPacket[check] < 0x3A){
			check = 5;
		}else{
			check = 0;
		}
	}else if(check == 5 && dataPacket[0] == "M"){
		dataPacket[check] = rData[0];
		if(dataPacket[check] > 0x2F && dataPacket[check] < 0x3A){
			check = 6;
		}else{
			check = 0;
		}
	}else if(check == 6 && dataPacket[0] == "M"){
		dataPacket[check] = rData[0];
		if(dataPacket[check] > 0x2F && dataPacket[check] < 0x3A){
			check = 0;
			packetCompleted = 1;
		}else{
			check = 0;
		}
	}
}

void convertDataNumber(void){
	for(uint8_t i = 2; i < 7; i++){
		dataStepArray[i-2] = dataPacket[i];
	}
	dataStepArray[5] = '\0';
	stepValue = atoi(dataStepArray);
}

/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
	/* User can add his own implementation to report the HAL error return state */
	__disable_irq();
	while (1) {
	}
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

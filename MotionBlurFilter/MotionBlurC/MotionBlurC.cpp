#include "pch.h"
#include "MotionBlurC.h"
void ApplyMotionBlur(uint8_t* imageData, int startX, int endX, int width, int height, int radius) {
    int bytesPerPixel = 3; // 3 bajty na piksel dla RGB
    int stride = width * bytesPerPixel; // D³ugoœæ jednego wiersza danych obrazu

    // Tworzymy tymczasow¹ tablicê dla rozmytych pikseli
    uint8_t* blurredData = (uint8_t*)malloc(height * stride);
    if (!blurredData) return; // Sprawdzamy, czy uda³o siê przydzieliæ pamiêæ

    // Przetwarzanie obrazu w pionowych pasach
    for (int x = startX; x < endX; x++) {
        for (int y = 0; y < height; y++) {
            int redSum = 0, greenSum = 0, blueSum = 0;
            int count = 0;

            // Zbieranie pikseli w pionie
            for (int dy = -radius; dy <= radius; dy++) {
                int ny = y + dy; // Nowa pozycja Y
                if (ny >= 0 && ny < height) { // Sprawdzamy granice obrazu
                    int index = ny * stride + x * bytesPerPixel; // Indeks w tablicy
                    blueSum += imageData[index];           // Akumulujemy niebieski
                    greenSum += imageData[index + 1];     // Akumulujemy zielony
                    redSum += imageData[index + 2];       // Akumulujemy czerwony
                    count++;                               // Liczymy piksele 
                }
            }

            // Uœrednianie wartoœci RGB i zapis do tymczasowej tablicy
            if (count > 0) {
                int blurredIndex = y * stride + x * bytesPerPixel; // Indeks w tablicy rozmytych pikseli
                blurredData[blurredIndex] = blueSum / count; // Niebieski
                blurredData[blurredIndex + 1] = greenSum / count; // Zielony
                blurredData[blurredIndex + 2] = redSum / count; // Czerwony
            }
        }
    }

    // Przenosimy rozmyte piksele do oryginalnych danych obrazu
    for (int y = 0; y < height; y++) {
        for (int x = startX; x < endX; x++) {
            int blurredIndex = y * stride + x * bytesPerPixel; // Indeks w tablicy rozmytych pikseli
            int originalIndex = y * stride + x * bytesPerPixel; // Indeks w tablicy oryginalnych pikseli

            // Przypisujemy rozmyte wartoœci do oryginalnej tablicy
            imageData[originalIndex] = blurredData[blurredIndex]; // Niebieski
            imageData[originalIndex + 1] = blurredData[blurredIndex + 1]; // Zielony
            imageData[originalIndex + 2] = blurredData[blurredIndex + 2]; // Czerwony
        }
    }

    free(blurredData); // Zwalniamy pamiêæ
}
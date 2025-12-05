#include <iostream>
#include <vector>
#include <fstream>
#include <string>
#include <sstream>

std::vector<std::string> extractInput() {
    std::string line;
    std::vector<std::string> input;
    std::ifstream readFile("input");
        while (std::getline(readFile, line)) {
            input.push_back(line);
        }
    readFile.close();
    return input;
}

int solution1(const std::vector<std::string> &input) {
    //initialize variables
    int result = 0, current = 50;
    char rotation;
    int degrees = 0;


    for (int i = 0; i < input.size(); i++) {
        //use stringstream to seperate rotation and degrees
        std::stringstream ss(input[i]);
        ss >> rotation;
        ss >> degrees;

        // Calculate new number and increment result if it is 0
        if (rotation == 'R')
            current = (current + degrees) % 100;
        else if (rotation == 'L')
            current = (current - degrees) % 100;
        else
            std::cerr << "Invalid rotation" << std::endl;

        if (current == 0)
            result++;
    }
    return result;
}

int zeroCrossesRight(int current, int degrees) {
    if (current == 0) {
        if (degrees < 100) return 0;
        return degrees / 100;
    }
    int first = 100 - current;
    if (degrees < first) return 0;
    return 1 + (degrees - first) / 100;
}

int zeroCrossesLeft(int current, int degrees) {
    if (current == 0) {
        if (degrees < 100) return 0;
        return degrees / 100;
    }
    int first = current;
    if (degrees < first) return 0;
    return 1 + (degrees - first) / 100;
}

int solution2(const std::vector<std::string> &input) {
    int result = 0;
    int current = 50;
    char rotation;
    int degrees = 0;

    for (const auto &line : input) {
        std::stringstream ss(line);
        ss >> rotation >> degrees;

        if (rotation == 'R') {
            int zeroCrosses = zeroCrossesRight(current, degrees);
            result += zeroCrosses;
            current = (current + degrees) % 100;
        }
        else if (rotation == 'L') {
            int zeroCrosses = zeroCrossesLeft(current, degrees);
            current = current - degrees;
            current %= 100;
            if (current < 0) current += 100;
            result += zeroCrosses;
        }
        else {
            std::cerr << "Invalid rotation: " << rotation << '\n';
        }
    }
    return result;
}

int star1(){
    std::vector<std::string> input = extractInput();
    return solution1(input);
}

int star2() {
    std::vector<std::string> input =  extractInput();
    return solution2(input);
}

int main() {
    std::cout << "Star 1: " << star1() << std::endl;
    std::cout << "Star 2: " << star2() << std::endl;
    return 0;
}
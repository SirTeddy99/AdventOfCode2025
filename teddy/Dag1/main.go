// Package main is used for...
package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
)

// func main() {
// 	Magic := -762
//
// 	number := Magic / 100
// 	fmt.Printf("%v \n", number)
// 	number *= 100
// 	fmt.Printf("%v \n", number)
// 	Magic -= number
// 	fmt.Printf("%v \n", Magic)
// }

func main() {
	fmt.Printf("Starting program...")

	// Open the file for reading
	file, err := os.Open("foo.txt")
	if err != nil {
		log.Fatalf("Error opening file: %v", err)
	}
	defer file.Close()

	// Create a scanner to read the file line by line
	scanner := bufio.NewScanner(file)

	var UpOrDownList []string
	var NumberList []string

	// Loop through each line in the file
	for scanner.Scan() {
		// Get the current line from the scanner
		line := scanner.Text()

		UpOrDown := string(line[0])
		number := string(line[1:])

		// fmt.Println("up or down:", UpOrDown)
		UpOrDownList = append(UpOrDownList, UpOrDown)
		// fmt.Println("number:", number)
		NumberList = append(NumberList, number)
	}
	// fmt.Println("list UpOrDownList", UpOrDownList)
	// fmt.Println("list NumberList", NumberList)

	fmt.Printf("\n ------ \n")
	fmt.Printf("\n ------ \n")
	fmt.Printf("\n ------ \n")
	fmt.Printf("\n ------ \n")
	fmt.Printf("\n ------ \n")
	fmt.Printf("\n ------ \n")
	fmt.Printf("\n ------ \n")
	lengthy := len(UpOrDownList)

	Magic := 50
	Yeet := 0
	inoyingProblem := false

	for i := 0; i <= lengthy-1; i++ {
		fmt.Printf("\n------ \n")
		fmt.Printf("Round %v \n", i+1)
		fmt.Printf("------ \n")
		// fmt.Printf("Magic = %v \n", Magic)

		// fmt.Printf("%v", UpOrDownList[i])
		UoD := UpOrDownList[i]
		// fmt.Printf("%v \n", NumberList[i])
		N, err := strconv.Atoi(NumberList[i])

		if err != nil {
			log.Fatalln("intify dont work...", err)
		}

		x := 0
		ifPlussRound := 0
		ifMinusRound := 0
		if UoD == "L" {
			Magic -= N

			if Magic < 0 {
				x = Magic / 100
				yoot := x * 100
				Magic -= yoot
				Magic += 100
				if x == 0 {
					ifMinusRound = 1
					if inoyingProblem && ifMinusRound != 0 {
						ifMinusRound += -1
					}
				}
				x *= -1

			}
		} else {
			Magic += N
			if Magic > 99 {
				x = Magic / 100
				yoot := x * 100
				Magic -= yoot
				if Magic == 0 {
					ifPlussRound += -1
				}
			}
		}
		inoyingProblem = false
		if Magic == 0 {
			Yeet++
			fmt.Printf("magic = %v \n", Magic)
			inoyingProblem = true
		}
		fmt.Printf("what is x = %v \n", x)
		fmt.Printf("what is ifMinusRound = %v \n", ifMinusRound)
		fmt.Printf("what is ifPlussRound = %v \n", ifPlussRound)
		fmt.Printf("Magic = %v \n", Magic)

		Yeet += x
		Yeet += ifMinusRound
		Yeet += ifPlussRound
		fmt.Printf("Yeetus Maximus = %v \n", Yeet)
		// x = 0
		ifPlussRound = 0
		ifMinusRound = 0
	}
	// fmt.Printf("Magic = %v \n", Magic)
	fmt.Printf("\n ------ \n")
	fmt.Printf("Yeet = %v \n", Yeet)
	fmt.Printf("------ \n")

}

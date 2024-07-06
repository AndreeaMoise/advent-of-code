import { solvePart1 } from "./solvers.js";
import { readFile } from "../../read_file.js";

const main = async () => {
	const filePath = 'input2.txt';

	var entries = await readFile(filePath);
	
	const part1 = solvePart1(entries);
	//const part2 = solvePart2(entries);
	
	console.log("Part 1: ", part1);
	//console.log("Part 2: ", part2);
	
	return entries;
}

main();
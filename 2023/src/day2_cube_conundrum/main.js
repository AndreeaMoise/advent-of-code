import { solvePart1, solvePart2, parseEntries } from "./solvers.js";
import { readFile } from "../../read_file.js";

const main = async () => {
	const filePath = 'input2.txt';

	var entries = await readFile(filePath);
	var parsedEntries = parseEntries(entries);
	const part1 = solvePart1(parsedEntries);
	const part2 = solvePart2(parsedEntries);
	
	console.log("Part 1: ", part1);
	console.log("Part 2: ", part2);
	
	return entries;
}

main();
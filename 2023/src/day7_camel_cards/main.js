import { solvePart1, solvePart2 } from "./solvers.js";
import { readFile } from "../../read_file.js";
import { parseEntries } from "../day7_camel_cards/solvers.js";

const main = async () => {
	const filePath = 'input2.txt';

	const entries = await readFile(filePath);
	const parsedEntries = parseEntries(entries);
	
	//const part1 = solvePart1(parsedEntries);
	const part2 = solvePart2(parsedEntries);
	
	//console.log("Part 1: ", part1);
	console.log("Part 2: ", part2);
	
	return entries;
}

main();
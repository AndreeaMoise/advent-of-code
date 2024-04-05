import fs from 'fs';

export const readFile = async (filePath) => {
	var array = fs.readFileSync(filePath).toString().split("\n").map(str => str.replace("\r", ""));
	console.log(array);
	return array;
}

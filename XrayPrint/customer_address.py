import win32gui,win32con,win32api,win32ui
# import re
import pyautogui
import re, traceback
import time
import datetime
import sys
import tempfile
import argparse
import os

# import xlsxwriter

# from PIL import Image
# import pytesseract
# import cv2

# url = 'http://192.168.10.20:8004/api'
# url = 'http://127.0.0.1:8000/api'
x = 0
y = 0 
w = 0
h = 0 
vHeighScreen = 0
vBookingCreatePage = False
vCuurentBookingMode = ''
x_capture =0
y_capture = 0
w_capture = 0
h_capture = 0

class bcolors:
	HEADER = '\033[95m'
	OKBLUE = '\033[94m'
	OKGREEN = '\033[92m'
	WARNING = '\033[93m'
	FAIL = '\033[91m'
	ENDC = '\033[0m'
	BOLD = '\033[1m'
	UNDERLINE = '\033[4m'


class WindowMgr:
	"""Encapsulates some calls to the winapi for window management"""
	settingFile =''


	def __init__ (self):
		"""Constructor"""
		self.hwnd = None

	def find_window(self,title):
		try:
			self.hwnd = win32gui.FindWindow(None, title)
			assert self.hwnd
			return self.hwnd
		except:
			pyautogui.alert(text='Not found program name ' + title + '\n' 
							'Please open program before excute script', title='Unable to open program', button='OK')
			# print ('Not found program')
			return None


	def set_onTop(self,hwnd):
		win32gui.SetForegroundWindow(hwnd)
		return win32gui.GetWindowRect(hwnd)



	def Maximize(self,hwnd):
		win32gui.ShowWindow(hwnd,win32con.SW_RESTORE)#, win32con.SW_MAXIMIZE

	def get_mouseXY(self):
		return win32gui.GetCursorPos()

	def set_mouseXY(self):
		import os.path
		import json
		x,y,w,h = win32gui.GetWindowRect(self.hwnd)
		print ('Current Window X : %s  Y: %s' %(x,y))
		fname = 'setting.json'
		if os.path.isfile(fname) :
			dict = eval(open(fname).read())
			x1 = dict['x']
			y1 = dict['y']
			print ('Setting X : %s  Y: %s' %(x1,y1))
		win32api.SetCursorPos((x+x1,y+y1))
		win32api.mouse_event(win32con.MOUSEEVENTF_LEFTDOWN, x+x1, y+y1, 0, 0)
		win32api.mouse_event(win32con.MOUSEEVENTF_LEFTUP, x+x1, y+y1, 0, 0)
		print ('Current Mouse X %s' % self.get_mouseXY()[0])
		print ('Current Mouse Y %s' % self.get_mouseXY()[1])


	def saveFirstDataPos(self):
		x,y,w,h = win32gui.GetWindowRect(self.hwnd)
		print ('Window X : %s  Y: %s' %(x,y))
		x1,y1 = self.get_mouseXY()
		print ('Mouse X : %s  Y: %s' %(x1,y1))
		data={}
		data['x'] = x1-x
		data['y'] = y1-y
		# f = open("setting.json", "w")
		# self.settingFile
		f = open(settingFile, "w")
		f.write(str(data))

		f.close()

	def wait(self,seconds=1,message=None):
		"""pause Windows for ? seconds and print
an optional message """
		win32api.Sleep(seconds*1000)
		if message is not None:
			win32api.keybd_event(message, 0,0,0)
			time.sleep(.05)
			win32api.keybd_event(message,0 ,win32con.KEYEVENTF_KEYUP ,0)

	def typer(self,stringIn=None):
		PyCWnd = win32ui.CreateWindowFromHandle(self.hwnd)
		for s in stringIn :
			if s == "\n":
				self.hwnd.SendMessage(win32con.WM_KEYDOWN, win32con.VK_RETURN, 0)
				self.hwnd.SendMessage(win32con.WM_KEYUP, win32con.VK_RETURN, 0)
			else:
				print ('Ord %s' % ord(s))
				PyCWnd.SendMessage(win32con.WM_CHAR, ord(s), 0)
		PyCWnd.UpdateWindow()

	def WindowExists(windowname):
		try:
			win32ui.FindWindow(None, windowname)

		except win32ui.error:
			return False
		else:
			return True



def main():
	import json
	import sys
	from colorama import init, AnsiToWin32,Fore, Back, Style
	import math
	# import datetime
	init(wrap=False)
	stream = AnsiToWin32(sys.stderr).stream

	try:
		ldir = tempfile.mkdtemp()
		parser = argparse.ArgumentParser()
		parser.add_argument('-d', '--directory', default=ldir)
		args = parser.parse_args()
		tmpDir = args.directory
		# print (tmpDir)

		fname = 'fullout_setting.json'

		regex = "Session C - [24 x 80]"
		state_left = win32api.GetKeyState(0x01)  # Left button down = 0 or 1. Button up = -127 or -128
		state_right = win32api.GetKeyState(0x02)  # Right button down = 0 or 1. Button up = -127 or -128

		import os.path
		secs_between_keys=0.01

		win = WindowMgr()
		win_ins = win.find_window(regex)

	   
		print (Style.RESET_ALL + '===Starting Process==', file=stream)
		if win_ins == None :
			print (Fore.RED + ('-Not found session : %s' % regex ), file=stream)
			print (Fore.RED + '-Please open CTCS program before execute..', file=stream)
			sys.exit()

		win.Maximize(win_ins)

		(x,y,w,h) =win.set_onTop(win_ins)
	  
		#  Initial -Setup
		pyautogui.press('f12')
		pyautogui.press('f12')
		pyautogui.press('f12')
		pyautogui.press('f12')
		#2) Now On "Product Environment LCB1" screen.
		#Need to input "1" --> Work with CTCS.
		pyautogui.typewrite('1', interval=secs_between_keys)
		pyautogui.press('enter')

		#3) Now On "Select one of following" screen.
		#Need to input "1" --> Order.
		pyautogui.typewrite('1', interval=secs_between_keys)
		pyautogui.press('enter')

		#3) Now On "CTS order" screen.
		#Need to input "2" -->  Full Out Order
		pyautogui.typewrite('2', interval=secs_between_keys)
		pyautogui.press('enter')

		# Reference Overview
		# pyautogui.press('down',4)

		


		# ====Start VGM ======
		# from openpyxl import load_workbook
		import io
		import glob
		import re
		rex = re.compile("^[A-Z]{4}[0-9]{7}$")


		file_list = glob.glob('fullout.txt')
		print (Fore.GREEN + ('==============================================' ), file=stream)

		if len(file_list) == 0 :
			print (Fore.RED +'Not found any fullout.txt file', file=stream)
			sys.exit()
		else:
			print ('Found %s' % file_list[0] )




		# sys.exit()


		for fullout_file in file_list:
			print (Fore.GREEN + ('File name : %s ' % fullout_file ), file=stream)                      
			# with open(fullout_file, "rb") as f:
			#     in_mem_file = io.BytesIO(f.read())
			# with open(fullout_file) as f:
			# 	lines = f.readlines()
			maxRow = 5000
			current_booking=''
			previous_booking =''
			first_booking = True

			lines = [line.rstrip('\n') for line in open(fullout_file)]

			for line in lines:
				data = line.split('|')

				booking = data[0]
				current_booking = booking
				container = data[1]
				line = data[2]
				agent = data[3]
				remark = data[4]
				untildate = data[5]
				carrier =data[6]
				#Added on April 30,2021 -- To receipe Address code
				code = data[7]
				#Added on May 11,2021 -- To fill paid until datetime
				paiduntil = data[8]

				pyautogui.typewrite(booking, interval=secs_between_keys)
				pyautogui.press('enter')

				pyautogui.typewrite('17', interval=secs_between_keys)
				pyautogui.press('enter')

				#Added on April 30,2021 -- To input address code direct to CTCS
				if not code == '' :
					#code is available
					pyautogui.typewrite(code, interval=secs_between_keys)

					if not paiduntil == '' :
						if len(code) < 12:
							pyautogui.press('tab')
						#remove /
						paiduntil = paiduntil.replace('/','')
						pyautogui.typewrite(paiduntil, interval=secs_between_keys)
						pyautogui.press('end')
						pyautogui.press('enter')

					pyautogui.press('enter')
				#End Code
				else :
					#To search Address by using company name with *
					pyautogui.press('f4')
					pyautogui.hotkey('shift', 'f2')
					pyautogui.press('down')
					pyautogui.press('down')
					## remark2 = remark.split('/')[0] -- 
					remark3 = remark.split('/')[0]
					remark_split = remark3.split(' ')
					if len(remark_split) > 1:
						remark2 = '%s %s' % (remark_split[0],remark_split[1])
					else :
						remark2 = remark_split[0]
					pyautogui.typewrite('%s*' % remark2[:10], interval=secs_between_keys)
					pyautogui.press('enter')
					#End address search

				#Address details must show
				
				#Added on May 11,2021 -- To select all container (Shift+F2) , then Enter
				pyautogui.hotkey('shift', 'f2')
				pyautogui.press('enter')

				print ('======Finished=======')
				sys.exit()
				# pyautogui.press('enter',3)

		print ('======Finished=======')
		# ====End VGM=======
		sys.exit()

	except Exception as e:
	# except:
		if hasattr(e, 'message'):
			print(e.message)
		else:
			print(e)
		print('Error on line {}'.format(sys.exc_info()[-1].tb_lineno), type(e).__name__, e)
		# f = open(tmpDir + "log.txt", "w")
		# f.write(traceback.format_exc())

def convert_txt_to_excel(text_file_name):
	head, tail = os.path.split(text_file_name)
	# print ('Convert file %s --%s' % (head,tail))
	with open(text_file_name) as f:
		content = f.readlines()
	content = [x.strip() for x in content]

	xls_name = '%s\\%s.xlsx' % (head,tail.split('.')[0])
	workbook = xlsxwriter.Workbook(xls_name)
	worksheet = workbook.add_worksheet('summary')
	worksheet.write(0, 1,'container')
	worksheet.write(0, 11,'line')
	worksheet.write(0, 12,'booking')
	worksheet.write(0, 14,'agent')
	worksheet.write(0, 15,'remark')

	idx = 0
	for c in content:
		if 'LINE =' in c :
			line = c.split('=')[1].strip()
		if 'AGENT =' in c :
			agent = c.split('=')[1].strip()
		if 'H02' in c :
			booking = c.split(' ')[0].replace('H02','')
		if 'H09' in c :
			container = c.split(' ')[0].replace('H09','')
			worksheet.write(idx+1, 1,container)
			worksheet.write(idx+1, 11,line)
			worksheet.write(idx+1, 12,booking)
			worksheet.write(idx+1, 14,agent)
			worksheet.write(idx+1, 15,'')
			idx=idx+1
	print ('Making Excel file completed')

	return xls_name

	


def create_order(booking,line,agent):
	secs_between_keys=0.01
	pyautogui.press('f6')
	pyautogui.typewrite(booking, interval=secs_between_keys)

	if len(booking) > 17 :
		booking = booking[-17:]
	# if booking >= 17 char ,No need to prees tab.
	if len(booking) < 17 :
		pyautogui.press('tab')
	
	pyautogui.typewrite(line, interval=secs_between_keys)
	pyautogui.press('tab')
	pyautogui.typewrite(agent, interval=secs_between_keys)
	pyautogui.press('enter')


def enter_container(container,remark,untildate,carrier):
	secs_between_keys=0.01
	pyautogui.typewrite(container, interval=secs_between_keys)
	pyautogui.press('tab',1)

	if untildate :
		pyautogui.typewrite(untildate, interval=secs_between_keys)
		
	if len(untildate) < 8:
		pyautogui.press('tab',7)
	else:
		pyautogui.press('tab',6)

	if carrier :
		pyautogui.typewrite(carrier, interval=secs_between_keys)

	if len(carrier) <17:
		pyautogui.press('tab',5)
	else:
		pyautogui.press('tab',4)

	pyautogui.typewrite(remark, interval=secs_between_keys)
	pyautogui.press('tab',2)
	pyautogui.typewrite('Y', interval=secs_between_keys)
	pyautogui.press('enter')

def enter_vgm(liner,vgm):
	secs_between_keys=0.01
	pyautogui.press('down',5)
	pyautogui.press('delete',12)
	pyautogui.typewrite(vgm, interval=secs_between_keys) #Enter Gross Weight
	pyautogui.press('tab',2)
	pyautogui.press('delete',12) #Delete Weight Net
	pyautogui.press('tab',6)
	pyautogui.typewrite('Y', interval=secs_between_keys)
	pyautogui.press('enter')

def enter_extra_vgm():
	secs_between_keys=0.01
	pyautogui.typewrite('VGM', interval=secs_between_keys)
	pyautogui.press('tab',14)
	pyautogui.typewrite('12', interval=secs_between_keys)
	# Ready Y/N on Screen
	filename="images/vgm.png"
	im = pyautogui.screenshot(filename,region=(x_capture,y_capture,w_capture,h_capture))
	text = pytesseract.image_to_string(Image.open(filename), \
				config="--psm 6 --eom 3 -c tessedit_char_whitelist=-01234567890yXYZ:")
	print ('Reading value %s' % text)
	newVGM = False
	if ('N' in text) or ('I' in text):
		newVGM = True
	pyautogui.press('enter')
	return newVGM

def enter_verify_vgm(liner,vgm):
	secs_between_keys=0.01
	pyautogui.press('f6')
	pyautogui.typewrite(vgm, interval=secs_between_keys)
	pyautogui.press('tab',1)
	pyautogui.typewrite(liner, interval=secs_between_keys)
	pyautogui.press('enter')

def mofify_verify_vgm(liner,vgm):
	secs_between_keys=0.01
	pyautogui.typewrite('2', interval=secs_between_keys)
	pyautogui.press('enter')
	pyautogui.press('delete',9)
	pyautogui.typewrite(vgm, interval=secs_between_keys)
	pyautogui.press('enter')



main()

#2558